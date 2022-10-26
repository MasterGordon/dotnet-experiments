class MultiPlayerGame : Game
{
    private Context ctx;

    public MultiPlayerGame(bool isHost)
    {
        var window = new Window("MultiPlayerGame", 1200, 800);
        if (isHost)
        {
            this.ctx = new Context(
                    isHost,
                    new Backend(),
                    new Frontend(),
                    new GameState(),
                    new FrontendGameState(),
                    new Renderer(window),
                    window
                );
        }
        else
        {
            this.ctx = new Context(
                    isHost,
                    new RemoteBackend(),
                    new Frontend(),
                    new GameState(),
                    new FrontendGameState(),
                    new Renderer(window),
                    window
                );
        }
        ctx.Frontend.Init();
        ctx.Backend.Init();
    }

    protected override void draw()
    {
        ctx.Frontend.Process();
    }

    protected override void update(double dt)
    {
        ctx.Backend.Process(dt);
    }
}
