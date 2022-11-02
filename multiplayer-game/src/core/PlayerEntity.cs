class PlayerEntity
{
    public static bool isSelf(Player p)
    {
        return p.Guid == GetSelf().Guid;
    }

    public static Player GetSelf()
    {
        var ctx = Context.Get();
        var player = ctx.GameState.Players.FirstOrDefault(
            p => p.Guid == ctx.FrontendGameState.PlayerGuid
        );
        return player;
    }

    public static void Move(Player p)
    {
        var ctx = Context.Get();
        p.Movement = p.Movement + Constants.gravity;
        p.Position += p.Movement;
    }

    public static void Collide(Player p)
    {
        var world = Context.Get().GameState.World;
        if (!world.HasChunkAt(p.Position))
        {
            return;
        }
        var chunk = world.GetChunkAt(p.Position);
        while (chunk.hasTileAt(p.Position))
        {
            p.Movement = p.Movement with { Y = 0 };
            p.Position += new Vector2(0, -0.1f);
        }
    }
}
