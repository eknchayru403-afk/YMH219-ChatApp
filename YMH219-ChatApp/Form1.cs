using System.Net;
using System.Net.Sockets;

namespace YMH219_ChatApp;

public partial class Form1 : Form
{
    private TcpListener? _listener;
    private CancellationTokenSource? _cts;
    private readonly List<ClientInfo> _clients = new();
    private readonly object _lock = new();

    public Form1()
    {
        InitializeComponent();
        btnStart.Click += btnStart_Click;
        btnStop.Click += btnStop_Click;
        FormClosing += (s, e) => StopServer();
    }

    private async void btnStart_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
        {
            MessageBox.Show("Geçerli bir port girin (1-65535).");
            return;
        }

        try
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
        }
        catch (SocketException ex)
        {
            MessageBox.Show("Sunucu başlatılamadı: " + ex.Message);
            return;
        }

        _cts = new CancellationTokenSource();
        btnStart.Enabled = false;
        btnStop.Enabled = true;
        txtPort.Enabled = false;
        lblStatus.Text = "Durum: Çalışıyor (port " + port + ")";
        Log("Sunucu başlatıldı.");

        await AcceptLoopAsync(_cts.Token);
    }

    private void btnStop_Click(object? sender, EventArgs e) => StopServer();

    private async Task AcceptLoopAsync(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested)
            {
                TcpClient tcp = await _listener!.AcceptTcpClientAsync(token);
                _ = HandleClientAsync(tcp, token);
            }
        }
        catch (OperationCanceledException) { }
        catch (ObjectDisposedException) { }
        catch (SocketException ex) { Log("Bağlantı kabul hatası: " + ex.Message); }
    }

    private async Task HandleClientAsync(TcpClient tcp, CancellationToken token)
    {
        var info = new ClientInfo(tcp);
        try
        {
            using var reader = new StreamReader(tcp.GetStream());

            string? first = await reader.ReadLineAsync(token);
            if (first == null || !first.StartsWith("JOIN|")) return;

            info.UserName = first.Substring(5).Trim();
            if (info.UserName == "") return;

            lock (_lock) _clients.Add(info);
            RefreshClientList();
            Log($"{info.UserName} bağlandı ({info.Address}).");
            await BroadcastAsync($"SYS|{info.UserName} sohbete katıldı.");

            while (!token.IsCancellationRequested)
            {
                string? line = await reader.ReadLineAsync(token);
                if (line == null) break; // istemci bağlantıyı kapattı

                if (line.StartsWith("MSG|"))
                {
                    string text = line.Substring(4);
                    Log($"{info.UserName}: {text}");
                    await BroadcastAsync($"MSG|{info.UserName}|{text}");
                }
            }
        }
        catch (OperationCanceledException) { }
        catch (IOException) { }
        catch (Exception ex) { Log("İstemci hatası: " + ex.Message); }
        finally
        {
            bool wasListed;
            lock (_lock) wasListed = _clients.Remove(info);
            tcp.Close();

            if (wasListed)
            {
                RefreshClientList();
                Log($"{info.UserName} ayrıldı.");
                if (!token.IsCancellationRequested)
                    await BroadcastAsync($"SYS|{info.UserName} sohbetten ayrıldı.");
            }
        }
    }

    private async Task BroadcastAsync(string message)
    {
        List<ClientInfo> snapshot;
        lock (_lock) snapshot = _clients.ToList();

        foreach (var c in snapshot)
        {
            try { await c.Writer.WriteLineAsync(message); }
            catch (Exception) { /* bu istemci kopmuş olabilir, diğerlerine devam */ }
        }
    }

    private void StopServer()
    {
        if (_cts == null) return;

        _cts.Cancel();
        _listener?.Stop();

        List<ClientInfo> snapshot;
        lock (_lock)
        {
            snapshot = _clients.ToList();
            _clients.Clear();
        }
        foreach (var c in snapshot)
        {
            try { c.Client.Close(); } catch (Exception) { }
        }

        _cts = null;
        if (IsDisposed) return;

        RefreshClientList();
        btnStart.Enabled = true;
        btnStop.Enabled = false;
        txtPort.Enabled = true;
        lblStatus.Text = "Durum: Durduruldu";
        Log("Sunucu durduruldu.");
    }

    private void RefreshClientList()
    {
        if (IsDisposed) return;
        List<ClientInfo> snapshot;
        lock (_lock) snapshot = _clients.ToList();

        lstClients.Items.Clear();
        foreach (var c in snapshot) lstClients.Items.Add(c.ToString());
    }

    private void Log(string text)
    {
        if (IsDisposed) return;
        lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] {text}");
        lstLog.TopIndex = lstLog.Items.Count - 1;
    }
}