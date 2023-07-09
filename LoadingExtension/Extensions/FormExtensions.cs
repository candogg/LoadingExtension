using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadingExtension.Extensions
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public static class FormExtensions
    {
        public static void InvokeAsUIThread(this Control c, MethodInvoker action)
        {
            try
            {
                if (c == null || !c.IsHandleCreated) return;

                c.Invoke((MethodInvoker)delegate { action(); });
            }
            catch
            { }
        }

        public static Panel ShowLoadingOnForm(this Control c, Image loadingImage, Size loadingSize, Action cancelJobCallback = null, string cancelJobText = null)
        {
            try
            {
                var contentPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White
                };

                c.Controls.Add(contentPanel);

                var cancelButton = new Button
                {
                    Width = loadingSize.Width,
                    Height = 30,
                };

                var pctBox = new PictureBox
                {
                    Image = loadingImage,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = loadingSize
                };

                contentPanel.Controls.Add(pctBox);

                if (cancelJobCallback != null && cancelJobText.IsNotNullOrEmpty())
                {
                    cancelButton.Text = cancelJobText;

                    cancelButton.Click += (ss, ee) =>
                    {
                        Task.Run(() =>
                        {
                            cancelJobCallback?.Invoke();
                        });
                    };

                    contentPanel.Controls.Add(cancelButton);
                }

                contentPanel.BringToFront();

                var pctBoxTop = cancelJobCallback == null ? (contentPanel.Height - pctBox.Height) / 2 : (((contentPanel.Height - pctBox.Height) / 2) - (cancelButton.Height + 20));

                pctBox.Left = (contentPanel.Width - pctBox.Width) / 2;
                pctBox.Top = pctBoxTop;

                if (cancelJobCallback != null && cancelJobText.IsNotNullOrEmpty())
                {
                    cancelButton.Left = (contentPanel.Width - cancelButton.Width) / 2;
                    cancelButton.Top = pctBox.Top + pctBox.Height + 20;
                }
                else
                {
                    cancelButton.Dispose();
                }

                c.SizeChanged += (ss, ee) =>
                {
                    pctBoxTop = cancelJobCallback == null ? (contentPanel.Height - pctBox.Height) / 2 : (((contentPanel.Height - pctBox.Height) / 2) - (cancelButton.Height + 20));

                    pctBox.Left = (contentPanel.Width - pctBox.Width) / 2;
                    pctBox.Top = pctBoxTop;

                    if (cancelJobCallback != null && cancelJobText.IsNotNullOrEmpty())
                    {
                        cancelButton.Left = (contentPanel.Width - cancelButton.Width) / 2;
                        cancelButton.Top = pctBox.Top + pctBox.Height + 20;
                    }
                };

                return contentPanel;
            }
            catch
            { }

            return null;
        }

        public static void CloseLoadingOnForm(this Control c, Control contentPanel)
        {
            try
            {
                c.Controls.Remove(contentPanel);

                contentPanel.Dispose();
            }
            catch
            { }
        }
    }
}
