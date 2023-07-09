using LoadingExtension.Extensions;
using LoadingExtension.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadingExtension
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public partial class FrmMain : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private Task heavyTask;
        private bool canClose;
        private bool closeRequired;

        public FrmMain()
        {
            InitializeComponent();

            cancellationTokenSource = new CancellationTokenSource();

            canClose = true;
            closeRequired = false;
        }

        private void BtnHeavyLoad_Click(object sender, EventArgs e)
        {
            if (TxtTimeout.Text.IsNullOrEmpty() || !int.TryParse(TxtTimeout.Text, out var timeout))
            {
                MessageBox.Show("Wront timeout!");

                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            var contentPanel = this.ShowLoadingOnForm(Resources.dring, new Size(100, 100), CancelHeavyTaskCallback, "İşi İptal Et");

            heavyTask = HeavyTask(timeout).ContinueWith(result =>
            {
                this.InvokeAsUIThread(() =>
                {
                    this.CloseLoadingOnForm(contentPanel);

                    canClose = true;
                });
            });
        }

        private void BtnHeavyLoad2_Click(object sender, EventArgs e)
        {
            if (TxtTimeout.Text.IsNullOrEmpty() || !int.TryParse(TxtTimeout.Text, out var timeout))
            {
                MessageBox.Show("Wront timeout!");

                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            var contentPanel = this.ShowLoadingOnForm(Resources.dring, new Size(100, 100));

            heavyTask = HeavyTask(timeout).ContinueWith(result =>
            {
                this.InvokeAsUIThread(() =>
                {
                    this.CloseLoadingOnForm(contentPanel);

                    canClose = true;
                });
            });
        }

        private void CancelHeavyTaskCallback()
        {
            //Cancel job

            if (MessageBox.Show("İşi iptal etmek istediğinizden emin misiniz?", "İş İptali", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cancellationTokenSource?.Cancel();

                WaitTaskToComplete();
            }
        }

        private Task HeavyTask(int simulationJobInSeconds = 5)
        {
            canClose = false;

            return Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(simulationJobInSeconds), cancellationTokenSource.Token);
            }, cancellationTokenSource.Token);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeRequired = true;

            e.Cancel = !canClose;

            if (!canClose)
            {
                cancellationTokenSource?.Cancel();

                WaitTaskToComplete();
            }
        }

        private void WaitTaskToComplete()
        {
            Task.WhenAll(new Task[] { heavyTask }.Where(x => x != null)).ContinueWith(result =>
            {
                canClose = true;

                this.InvokeAsUIThread(() => { if (!closeRequired) return; Close(); });
            });
        }
    }
}
