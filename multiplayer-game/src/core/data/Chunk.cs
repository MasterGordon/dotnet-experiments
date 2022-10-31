class Chunk
{
    public int[][] Tiles { get; set; } = new int[Constants.ChunkSize][];
    public int X { get; set; }
    public int Y { get; set; }

    public Chunk(int x, int y)
    {
        X = x;
        Y = y;
        for (int i = 0; i < Constants.ChunkSize; i++)
        {
            Tiles[i] = new int[Constants.ChunkSize];
        }
    }

    public void SetTile(int x, int y, int tile)
    {
        Tiles[x][y] = tile;
    }
}
