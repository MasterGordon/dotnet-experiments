using System.Numerics;
using System.Text;
using Newtonsoft.Json;
using WatsonTcp;

class Backend : IBackend
{
    private WatsonTcpServer server;

    public void Process(double dt)
    {
        var ctx = Context.Get();
        ctx.GameState.PlayerPositions.ForEach(player =>
        {
            player.position += player.movement;
        });
        this.sendGameState();
    }

    public void ProcessPacket(ValueType packet)
    {
        var gameState = Context.Get().GameState;
        if (packet is MovePacket movePacket)
        {
            if (
                gameState.PlayerPositions.Find(player => player.name == movePacket.playerName)
                is Player player
            )
            {
                player.movement = movePacket.movement * 4;
            }
        }
        if (packet is ConnectPacket connectPacket)
        {
            Console.WriteLine($"Player {connectPacket.playerName} connected");
            gameState.PlayerPositions.Add(
                new Player
                {
                    name = connectPacket.playerName,
                    position = new Vector2(50, 50),
                    movement = new Vector2(0, 0)
                }
            );
        }
        this.sendGameState();
    }

    public void Init()
    {
        Task.Run(Run);
    }

    public void Run()
    {
        server = new WatsonTcpServer("127.0.0.1", 42069);
        server.Events.ClientConnected += this.clientConnected;
        server.Events.ClientDisconnected += this.clientDisconnected;
        server.Events.MessageReceived += this.messageReceived;
        server.Start();
    }

    private void clientConnected(object? sender, ConnectionEventArgs args)
    {
        Console.WriteLine("Client connected: " + args.IpPort);
        var gameState = Context.Get().GameState;
        var json = JsonConvert.SerializeObject(gameState);
        if (sender is WatsonTcpServer server)
        {
            server.Send(args.IpPort, Encoding.UTF8.GetBytes(json));
        }
    }

    private void clientDisconnected(object? sender, DisconnectionEventArgs args)
    {
        Console.WriteLine("Client disconnected: " + args.IpPort);
    }

    private void messageReceived(object? sender, MessageReceivedEventArgs args)
    {
        var time = DateTime.Now;
        Console.WriteLine("Message Received: " + args.IpPort);
        var packet = Converter.ParsePacket(args.Data);
        Console.WriteLine("Received packet: " + packet);
        if (packet != null)
        {
            this.ProcessPacket(packet);
        }
        Console.WriteLine(DateTime.Now - time);
    }

    private void sendGameState()
    {
        if (server == null)
            return;
        var clients = server.ListClients();
        if (clients.Count() == 0)
            return;
        var gameState = Context.Get().GameState;
        var json = JsonConvert.SerializeObject(gameState);
        var bytes = Encoding.UTF8.GetBytes(json);
        foreach (var client in clients)
        {
            server.Send(client, bytes);
        }
    }
}
