using System.Numerics;

[Interactor]
class Connect
{
    [Interaction(InteractorKind.Server, "connect")]
    public static void ConnectServer(ConnectPacket packet)
    {
        var ctx = Context.Get();
        var player = ctx.GameState.PlayerPositions.Find(p => p.name == packet.playerName);
        if (player == null)
        {
            ctx.GameState.PlayerPositions.Add(
                new Player
                {
                    name = packet.playerName,
                    position = new Vector2(0, 0),
                    movement = new Vector2(0, 0)
                }
            );
        }
    }
}
