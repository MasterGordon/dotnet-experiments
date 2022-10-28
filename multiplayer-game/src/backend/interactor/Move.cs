[Interactor]
class Move
{
    [Interaction(InteractorKind.Hybrid, "move")]
    public static void MoveHybrid(MovePacket packet)
    {
        var ctx = Context.Get();
        var player = ctx.GameState.PlayerPositions.Find(p => p.name == packet.playerName);
        if (player != null)
        {
            player.movement = packet.movement * 4;
        }
    }
}
