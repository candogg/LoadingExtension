namespace LoadingExtension
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnHeavyLoad = new System.Windows.Forms.Button();
            this.BtnHeavyLoad2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTimeout = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnHeavyLoad
            // 
            this.BtnHeavyLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnHeavyLoad.Location = new System.Drawing.Point(137, 69);
            this.BtnHeavyLoad.Name = "BtnHeavyLoad";
            this.BtnHeavyLoad.Size = new System.Drawing.Size(378, 87);
            this.BtnHeavyLoad.TabIndex = 0;
            this.BtnHeavyLoad.Text = "Heavy Load Operation (With Cancellation)";
            this.BtnHeavyLoad.UseVisualStyleBackColor = true;
            this.BtnHeavyLoad.Click += new System.EventHandler(this.BtnHeavyLoad_Click);
            // 
            // BtnHeavyLoad2
            // 
            this.BtnHeavyLoad2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnHeavyLoad2.Location = new System.Drawing.Point(137, 162);
            this.BtnHeavyLoad2.Name = "BtnHeavyLoad2";
            this.BtnHeavyLoad2.Size = new System.Drawing.Size(378, 87);
            this.BtnHeavyLoad2.TabIndex = 1;
            this.BtnHeavyLoad2.Text = "Heavy Load Operation (Without Cancellation)";
            this.BtnHeavyLoad2.UseVisualStyleBackColor = true;
            this.BtnHeavyLoad2.Click += new System.EventHandler(this.BtnHeavyLoad2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Operation Simulation Time (seconds)";
            // 
            // TxtTimeout
            // 
            this.TxtTimeout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtTimeout.Location = new System.Drawing.Point(390, 24);
            this.TxtTimeout.Name = "TxtTimeout";
            this.TxtTimeout.Size = new System.Drawing.Size(125, 23);
            this.TxtTimeout.TabIndex = 3;
            this.TxtTimeout.Text = "10";
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(652, 319);
            this.Controls.Add(this.TxtTimeout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnHeavyLoad2);
            this.Controls.Add(this.BtnHeavyLoad);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnHeavyLoad;
        private System.Windows.Forms.Button BtnHeavyLoad2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTimeout;
    }
}

