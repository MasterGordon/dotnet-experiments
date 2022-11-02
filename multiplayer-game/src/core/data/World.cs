class World
{
    public Dictionary<string, Chunk> Chunks { get; set; } = new Dictionary<string, Chunk>();

    public void AddChunk(Chunk chunk)
    {
        Chunks.Add(chunk.X + "," + chunk.Y, chunk);
    }

    public Chunk GetChunk(Vector2 pos)
    {
        return GetChunk((int)pos.X, (int)pos.Y);
    }

    public Chunk GetChunk(int x, int y)
    {
        return Chunks[x + "," + y];
    }

    public Chunk GetChunkAt(Vector2 pos)
    {
        return GetChunkAt((int)pos.X, (int)pos.Y);
    }

    public Chunk GetChunkAt(int x, int y)
    {
        var chunkX = x / Constants.ChunkSize;
        var chunkY = y / Constants.ChunkSize;
        return Chunks[chunkX + "," + chunkY];
    }

    public bool HasChunkAt(Vector2 pos)
    {
        return HasChunkAt((int)pos.X, (int)pos.Y);
    }

    public bool HasChunkAt(int x, int y)
    {
        var chunkX = x / Constants.ChunkSize;
        var chunkY = y / Constants.ChunkSize;
        return Chunks.ContainsKey(chunkX + "," + chunkY);
    }

    public bool ChunkExists(int x, int y)
    {
        return Chunks.ContainsKey(x + "," + y);
    }
}
