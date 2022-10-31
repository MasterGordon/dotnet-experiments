class ChunkGenerator
{
    public static Chunk CreateFilledChunk(int x, int y, int fill)
    {
        Chunk chunk = new Chunk(x, y);
        for (int i = 0; i < Constants.ChunkSize; i++)
        {
            for (int j = 0; j < Constants.ChunkSize; j++)
            {
                chunk.SetTile(i, j, fill);
            }
        }
        return chunk;
    }

    public static Chunk CreateFilledChunk(int x, int y, Tiles fill)
    {
        return CreateFilledChunk(x, y, (int)fill);
    }
}
