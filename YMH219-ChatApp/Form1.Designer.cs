namespace YMH219_ChatApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtPort = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            lblStatus = new Label();
            label2 = new Label();
            lstClients = new ListBox();
            label3 = new Label();
            lstLog = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 53);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Port:";
            
            // 
            // txtPort
            // 
            txtPort.Location = new Point(113, 50);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 1;
            txtPort.Text = "5000";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(304, 50);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 2;
            btnStart.Text = "Başlat";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(461, 53);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 3;
            btnStop.Text = "Durdur";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(620, 57);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(136, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Durum: Durduruldu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 95);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 5;
            label2.Text = "Bağlı İstemciler";
            // 
            // lstClients
            // 
            lstClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lstClients.FormattingEnabled = true;
            lstClients.Location = new Point(20, 120);
            lstClients.Name = "lstClients";
            lstClients.Size = new Size(340, 304);
            lstClients.TabIndex = 6;
            
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(380, 95);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 7;
            label3.Text = "Sunucu Günlüğü";
            // 
            // lstLog
            // 
            lstLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(380, 120);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(400, 304);
            lstLog.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(lstLog);
            Controls.Add(label3);
            Controls.Add(lstClients);
            Controls.Add(label2);
            Controls.Add(lblStatus);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(txtPort);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Chat Sunucusu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPort;
        private Button btnStart;
        private Button btnStop;
        private Label lblStatus;
        private Label label2;
        private ListBox lstClients;
        private Label label3;
        private ListBox lstLog;
    }
}
