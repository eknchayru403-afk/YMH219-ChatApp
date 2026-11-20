using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class ChatClientConnection
    {
        private TcpClient _istemci;
        private StreamReader _okuyucu;
        private StreamWriter _yazici;

        public bool BagliMi => _istemci != null && _istemci.Connected;

        public event Action<string> MesajAlindi;
        public event Action<string> BaglantiKoptu;

        public async Task BaglanAsync(string ip, int port, string kullaniciAdi)
        {
            BaglantiyiKes();

            _istemci = new TcpClient();
            await _istemci.ConnectAsync(ip, port);

            NetworkStream agAkisi = _istemci.GetStream();
            _okuyucu = new StreamReader(agAkisi, Encoding.UTF8);
            _yazici = new StreamWriter(agAkisi, Encoding.UTF8) { AutoFlush = true };

            // Sunucunun beklediği JOIN protokolü ile kullanıcı adını gönder
            await _yazici.WriteLineAsync($"JOIN|{kullaniciAdi}");

            _ = DinleAsync();
        }

        private async Task DinleAsync()
        {
            try
            {
                while (BagliMi)
                {
                    string satir = await _okuyucu.ReadLineAsync();
                    if (satir == null)
                    {
                        break;
                    }

                    string formatli = ProtokolCoz(satir);
                    MesajAlindi?.Invoke(formatli);
                }
            }
            catch
            {
                // Bağlantı kapatıldığında veya koptuğunda döngüden çık
            }
            finally
            {
                bool onceBagliydi = _istemci != null;
                BaglantiyiKes();
                if (onceBagliydi)
                {
                    BaglantiKoptu?.Invoke("Sunucu ile bağlantı kesildi.");
                }
            }
        }

        private string ProtokolCoz(string satir)
        {
            string saat = DateTime.Now.ToString("HH:mm:ss");

            if (satir.StartsWith("SYS|"))
            {
                return $"[{saat}] [SİSTEM] {satir.Substring(4)}";
            }

            if (satir.StartsWith("MSG|"))
            {
                // Format: MSG|Gonderen|MesajMetni
                string[] parcalar = satir.Split(new[] { '|' }, 3);
                if (parcalar.Length == 3)
                {
                    return $"[{saat}] {parcalar[1]}: {parcalar[2]}";
                }
            }

            return $"[{saat}] {satir}";
        }

        public async Task MesajGonderAsync(string mesaj)
        {
            if (!BagliMi || _yazici == null || string.IsNullOrWhiteSpace(mesaj))
                return;

            // Sunucunun beklediği MSG| protokolü ile gönder
            await _yazici.WriteLineAsync($"MSG|{mesaj.Trim()}");
        }

        public void BaglantiyiKes()
        {
            try { _okuyucu?.Close(); } catch { }
            try { _yazici?.Close(); } catch { }
            try { _istemci?.Close(); } catch { }

            _okuyucu = null;
            _yazici = null;
            _istemci = null;
        }
    }
}