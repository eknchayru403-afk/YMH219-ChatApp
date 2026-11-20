using System.Net.Sockets;

namespace YMH219_ChatApp;

public class ClientInfo
{
    public string UserName { get; set; } = "";
    public TcpClient Client { get; }
    public StreamWriter Writer { get; }
    public DateTime ConnectedAt { get; } = DateTime.Now;

    public string Address =>
        Client.Client.RemoteEndPoint?.ToString() ?? "bilinmiyor";

    public ClientInfo(TcpClient client)
    {
        Client = client;
        Writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
    }

    public override string ToString() =>
        $"{UserName} - {Address} - {ConnectedAt:HH:mm:ss}";
}