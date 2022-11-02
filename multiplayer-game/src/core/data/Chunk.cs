class Chunk
{
    public int[,] Tiles { get; set; } = new int[Constants.ChunkSize, Constants.ChunkSize];
    public int X { get; set; }
    public int Y { get; set; }

    public Chunk(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void SetTile(int x, int y, int tile)
    {
        Tiles[x, y] = tile;
    }

    public int GetTile(int x, int y)
    {
        return Tiles[x, y];
    }

    public bool hasTileAt(Vector2 pos)
    {
        return hasTileAt((int)pos.X, (int)pos.Y);
    }

    public bool hasTileAt(int x, int y)
    {
        var tileX = x / Constants.TileSize;
        var tileY = y / Constants.TileSize;
        return hasTile(tileX, tileY);
    }

    public int GetTileAt(Vector2 pos)
    {
        return GetTileAt((int)pos.X, (int)pos.Y);
    }

    public int GetTileAt(int x, int y)
    {
        var tileX = x / Constants.TileSize;
        var tileY = y / Constants.TileSize;
        return GetTile(tileX, tileY);
    }

    public bool hasTile(int x, int y)
    {
        return x >= 0 && x < Tiles.Length && y >= 0 && y < Tiles.Length;
    }

    public bool hasTile(Vector2 pos)
    {
        return hasTile((int)pos.X, (int)pos.Y);
    }
}
