using System.Text;
using WatsonTcp;

class TcpClient
{
    public async Task Run()
    {
        var client = new WatsonTcpClient("127.0.0.1", 42069);
        client.Events.MessageReceived += this.onMessageReceived;
        client.Connect();
        await client.SendAsync("Hello World!");
        await Task.Delay(-1);
    }

    private void onMessageReceived(object? sender, MessageReceivedEventArgs args)
    {
        var messageString = Encoding.UTF8.GetString(args.Data);
        Console.WriteLine("Message received: " + messageString);
    }
}
