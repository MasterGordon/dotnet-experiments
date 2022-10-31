class WorldRenderer : IRenderer
{
    public void Render()
    {
        var ctx = Context.Get();
        var world = ctx.GameState.World;
        var renderer = ctx.Renderer;
        var tileRegistry = ctx.TileRegistry;
        foreach (var (_, chunk) in world.Chunks)
        {
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    var tileId = chunk.Tiles[x][y];
                    var tile = tileRegistry.GetTile(tileId);
                    tile.Render(x * 16, y * 16);
                }
            }
        }
    }
}
