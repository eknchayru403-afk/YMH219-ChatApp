namespace ChatClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblKullaniciAdi = new Label();
            txtKullaniciAdi = new TextBox();
            lblIp = new Label();
            txtIp = new TextBox();
            lblPort = new Label();
            txtPort = new TextBox();
            btnBaglan = new Button();
            btnBaglantiyiKes = new Button();
            lblDurum = new Label();
            rtbMesajlar = new RichTextBox();
            txtMesaj = new TextBox();
            btnGonder = new Button();
            SuspendLayout();

            // lblKullaniciAdi
            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblKullaniciAdi.Location = new Point(20, 18);
            lblKullaniciAdi.Name = "lblKullaniciAdi";
            lblKullaniciAdi.Size = new Size(105, 17);
            lblKullaniciAdi.Text = "Kullanıcı Adı:";

            // txtKullaniciAdi
            txtKullaniciAdi.Font = new Font("Segoe UI", 9.5F);
            txtKullaniciAdi.Location = new Point(125, 15);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(140, 25);
            txtKullaniciAdi.Text = "Kullanici1";

            // lblIp
            lblIp.AutoSize = true;
            lblIp.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblIp.Location = new Point(280, 18);
            lblIp.Name = "lblIp";
            lblIp.Size = new Size(28, 17);
            lblIp.Text = "IP:";

            // txtIp
            txtIp.Font = new Font("Segoe UI", 9.5F);
            txtIp.Location = new Point(312, 15);
            txtIp.Name = "txtIp";
            txtIp.Size = new Size(115, 25);
            txtIp.Text = "127.0.0.1";

            // lblPort
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPort.Location = new Point(440, 18);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(42, 17);
            lblPort.Text = "Port:";

            // txtPort
            txtPort.Font = new Font("Segoe UI", 9.5F);
            txtPort.Location = new Point(485, 15);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(70, 25);
            txtPort.Text = "5000";

            // btnBaglan
            btnBaglan.BackColor = Color.SeaGreen;
            btnBaglan.FlatStyle = FlatStyle.Flat;
            btnBaglan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBaglan.ForeColor = Color.White;
            btnBaglan.Location = new Point(20, 50);
            btnBaglan.Name = "btnBaglan";
            btnBaglan.Size = new Size(115, 30);
            btnBaglan.Text = "Bağlan";
            btnBaglan.UseVisualStyleBackColor = false;
            btnBaglan.Click += btnBaglan_Click;

            // btnBaglantiyiKes
            btnBaglantiyiKes.BackColor = Color.IndianRed;
            btnBaglantiyiKes.Enabled = false;
            btnBaglantiyiKes.FlatStyle = FlatStyle.Flat;
            btnBaglantiyiKes.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBaglantiyiKes.ForeColor = Color.White;
            btnBaglantiyiKes.Location = new Point(145, 50);
            btnBaglantiyiKes.Name = "btnBaglantiyiKes";
            btnBaglantiyiKes.Size = new Size(135, 30);
            btnBaglantiyiKes.Text = "Bağlantıyı Kes";
            btnBaglantiyiKes.UseVisualStyleBackColor = false;
            btnBaglantiyiKes.Click += btnBaglantiyiKes_Click;

            // lblDurum
            lblDurum.AutoSize = true;
            lblDurum.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDurum.ForeColor = Color.Crimson;
            lblDurum.Location = new Point(300, 56);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(135, 17);
            lblDurum.Text = "● Bağlantı Yok";

            // rtbMesajlar
            rtbMesajlar.BackColor = Color.White;
            rtbMesajlar.Font = new Font("Consolas", 9.5F);
            rtbMesajlar.Location = new Point(20, 92);
            rtbMesajlar.Name = "rtbMesajlar";
            rtbMesajlar.ReadOnly = true;
            rtbMesajlar.Size = new Size(535, 300);
            rtbMesajlar.Text = "";

            // txtMesaj
            txtMesaj.Enabled = false;
            txtMesaj.Font = new Font("Segoe UI", 10F);
            txtMesaj.Location = new Point(20, 405);
            txtMesaj.Name = "txtMesaj";
            txtMesaj.Size = new Size(415, 25);
            txtMesaj.KeyDown += txtMesaj_KeyDown;

            // btnGonder
            btnGonder.BackColor = Color.SteelBlue;
            btnGonder.Enabled = false;
            btnGonder.FlatStyle = FlatStyle.Flat;
            btnGonder.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGonder.ForeColor = Color.White;
            btnGonder.Location = new Point(445, 403);
            btnGonder.Name = "btnGonder";
            btnGonder.Size = new Size(110, 30);
            btnGonder.Text = "Gönder";
            btnGonder.UseVisualStyleBackColor = false;
            btnGonder.Click += btnGonder_Click;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(575, 450);
            Controls.Add(btnGonder);
            Controls.Add(txtMesaj);
            Controls.Add(rtbMesajlar);
            Controls.Add(lblDurum);
            Controls.Add(btnBaglantiyiKes);
            Controls.Add(btnBaglan);
            Controls.Add(txtPort);
            Controls.Add(lblPort);
            Controls.Add(txtIp);
            Controls.Add(lblIp);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(lblKullaniciAdi);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "YMH 219 - TCP Chat İstemcisi (Client)";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKullaniciAdi;
        private TextBox txtKullaniciAdi;
        private Label lblIp;
        private TextBox txtIp;
        private Label lblPort;
        private TextBox txtPort;
        private Button btnBaglan;
        private Button btnBaglantiyiKes;
        private Label lblDurum;
        private RichTextBox rtbMesajlar;
        private TextBox txtMesaj;
        private Button btnGonder;
    }
}