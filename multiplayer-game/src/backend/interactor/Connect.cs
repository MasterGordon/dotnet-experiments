using System.Numerics;

[Interactor]
class Connect
{
    [Interaction(InteractorKind.Server, "connect")]
    public static void ConnectServer(ConnectPacket packet)
    {
        var ctx = Context.Get();
        var player = ctx.GameState.Players.Find(p => p.name == packet.playerName);
        if (player == null)
        {
            ctx.GameState.Players.Add(
                new Player
                {
                    name = packet.playerName,
                    guid = packet.playerGuid,
                    position = new Vector2(0, 0),
                    movement = new Vector2(0, 0)
                }
            );
        }
    }
}
