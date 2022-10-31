class World
{
    public Dictionary<string, Chunk> Chunks { get; set; } = new Dictionary<string, Chunk>();

    public void AddChunk(Chunk chunk)
    {
        Chunks.Add(chunk.X + "," + chunk.Y, chunk);
    }

    public Chunk GetChunk(int x, int y)
    {
        return Chunks[x + "," + y];
    }

    public bool ChunkExists(int x, int y)
    {
        return Chunks.ContainsKey(x + "," + y);
    }
}
