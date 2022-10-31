using System.Numerics;

[Interactor]
class Move
{
    [Interaction(InteractorKind.Client, "move")]
    public static void MoveClient(MovePacket packet)
    {
        var ctx = Context.Get();
        var player = ctx.GameState.Players.Find(p => p.name == packet.playerName);
        if (player != null)
        {
            player.movement = packet.movement * 4;
        }
    }

    [Interaction(InteractorKind.Client, "tick")]
    public static void TickClient(TickPacket packet)
    {
        var ctx = Context.Get();
        foreach (var player in ctx.GameState.Players)
        {
            if (player.movement == Vector2.Zero)
            {
                continue;
            }
            player.position += player.movement;
            if (player.guid == ctx.FrontendGameState.PlayerGuid)
            {
                ctx.Backend.ProcessPacket(new SelfMovedPacket(player.position));
            }
        }
    }

    [Interaction(InteractorKind.Client, "selfMoved")]
    public static void SelfMovedClient(SelfMovedPacket packet)
    {
        var ctx = Context.Get();
        ctx.FrontendGameState.Camera.CenterOn(packet.target);
    }
}
