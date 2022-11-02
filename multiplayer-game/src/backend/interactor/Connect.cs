using System.Numerics;

[Interactor]
class Connect
{
    [Interaction(InteractorKind.Server, "connect")]
    public static void ConnectServer(ConnectPacket packet)
    {
        var ctx = Context.Get();
        var player = ctx.GameState.Players.Find(p => p.Name == packet.playerName);
        if (player == null)
        {
            ctx.GameState.Players.Add(
                new Player
                {
                    Name = packet.playerName,
                    Guid = packet.playerGuid,
                    Position = new Vector2(20, 0),
                    Movement = new Vector2(0, 0)
                }
            );
        }
    }
}
