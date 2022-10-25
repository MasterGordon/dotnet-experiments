using System.Text;
using WatsonTcp;

class TcpServer
{
    public async Task Run()
    {
        var server = new WatsonTcpServer("127.0.0.1", 42069);
        server.Events.ClientConnected += this.clientConnected;
        server.Events.ClientDisconnected += this.clientDisconnected;
        server.Events.MessageReceived += this.messageReceived;
        server.Start();
        await Task.Delay(-1);
    }

    private void clientConnected(object? sender, ConnectionEventArgs args)
    {
        Console.WriteLine("Client connected: " + args.IpPort);
    }

    private void clientDisconnected(object? sender, DisconnectionEventArgs args)
    {
        Console.WriteLine("Client disconnected: " + args.IpPort);
    }

    private void messageReceived(object? sender, MessageReceivedEventArgs args)
    {
        var message = Encoding.UTF8.GetString(args.Data);
        Console.WriteLine("Message received: " + args.IpPort + " " + message);
    }
}
