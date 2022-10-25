public class Program
{
    public static async Task Main(string[] args)
    {
        if (args.Contains("--host"))
        {
            var TcpListener = new TcpServer();
            await TcpListener.Run();
        }
        if (args.Contains("--client"))
        {
            var TcpClient = new TcpClient();
            await TcpClient.Run();
        }
    }
}
