class Program
{
    static void Main(string[] args)
    {
        bool isHost = args.Contains("--host");
        // bool isHost = true;
        var game = new MultiPlayerGame(isHost);
        game.Run();
    }
}
