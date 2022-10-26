using WatsonTcp;
using Newtonsoft.Json;
using System.Text;

class RemoteBackend : IBackend
{
    private WatsonTcpClient client;

    public void Process(double dt)
    {

    }

    public void ProcessPacket(ValueType packet)
    {
        var json = JsonConvert.SerializeObject(packet);
        var bytes = Encoding.UTF8.GetBytes(json);
        client.Send(bytes);
    }

    public void Init()
    {
        client = new WatsonTcpClient("127.0.0.1", 42069);
        client.Events.MessageReceived += (sender, args) =>
        {
            var ctx = Context.Get();
            var message = Encoding.UTF8.GetString(args.Data);
            var packet = JsonConvert.DeserializeObject<GameState>(message);
            if (packet != null)
            {
                ctx.GameState = packet;
            }
        };
        client.Connect();
    }
}
