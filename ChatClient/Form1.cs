using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        private readonly ChatClientConnection _baglanti;

        public Form1()
        {
            InitializeComponent();
            _baglanti = new ChatClientConnection();
            _baglanti.MesajAlindi += Baglanti_MesajAlindi;
            _baglanti.BaglantiKoptu += Baglanti_BaglantiKoptu;
        }

        private async void btnBaglan_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string ip = txtIp.Text.Trim();

            if (string.IsNullOrWhiteSpace(kullaniciAdi))
            {
                MessageBox.Show("Lütfen bir kullanıcı adı girin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ip))
            {
                MessageBox.Show("Lütfen geçerli bir sunucu IP adresi girin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPort.Text.Trim(), out int port) || port < 1024 || port > 65535)
            {
                MessageBox.Show("Lütfen 1024 ile 65535 arasında geçerli bir port numarası girin.", "Geçersiz Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnBaglan.Enabled = false;
            lblDurum.Text = "● Bağlanıyor...";
            lblDurum.ForeColor = Color.DarkOrange;

            try
            {
                await _baglanti.BaglanAsync(ip, port, kullaniciAdi);
                ArayuzBaglandi(true, $"● Bağlı ({kullaniciAdi})");
                MesajSatiriEkle($"[{DateTime.Now:HH:mm:ss}] Sunucuya bağlanıldı.");
                txtMesaj.Focus();
            }
            catch (Exception ex)
            {
                ArayuzBaglandi(false, "● Bağlantı Hatası");
                MessageBox.Show($"Sunucuya bağlanılamadı:\n{ex.Message}", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaglantiyiKes_Click(object sender, EventArgs e)
        {
            _baglanti.BaglantiyiKes();
            ArayuzBaglandi(false, "● Bağlantı Kesildi");
            MesajSatiriEkle($"[{DateTime.Now:HH:mm:ss}] Bağlantı sonlandırıldı.");
        }

        private async void btnGonder_Click(object sender, EventArgs e)
        {
            await MesajiGonderAsync();
        }

        private async void txtMesaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await MesajiGonderAsync();
            }
        }

        private async Task MesajiGonderAsync()
        {
            string mesaj = txtMesaj.Text.Trim();
            if (string.IsNullOrWhiteSpace(mesaj) || !_baglanti.BagliMi)
                return;

            try
            {
                await _baglanti.MesajGonderAsync(mesaj);
                txtMesaj.Clear();
                txtMesaj.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mesaj gönderilemedi:\n{ex.Message}", "Gönderim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Baglanti_MesajAlindi(string mesaj)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Baglanti_MesajAlindi), mesaj);
                return;
            }

            MesajSatiriEkle(mesaj);
        }

        private void Baglanti_BaglantiKoptu(string bilgi)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Baglanti_BaglantiKoptu), bilgi);
                return;
            }

            ArayuzBaglandi(false, "● Bağlantı Kesildi");
            MesajSatiriEkle($"[{DateTime.Now:HH:mm:ss}] {bilgi}");
        }

        private void ArayuzBaglandi(bool bagli, string durumMetni)
        {
            btnBaglan.Enabled = !bagli;
            txtKullaniciAdi.Enabled = !bagli;
            txtIp.Enabled = !bagli;
            txtPort.Enabled = !bagli;

            btnBaglantiyiKes.Enabled = bagli;
            txtMesaj.Enabled = bagli;
            btnGonder.Enabled = bagli;

            lblDurum.Text = durumMetni;
            lblDurum.ForeColor = bagli ? Color.SeaGreen : Color.Crimson;
        }

        private void MesajSatiriEkle(string satir)
        {
            rtbMesajlar.AppendText(satir + Environment.NewLine);
            rtbMesajlar.ScrollToCaret();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _baglanti.BaglantiyiKes();
        }
    }
}