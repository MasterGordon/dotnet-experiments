class FrontendGameState
{
    public Vector2 MovementInput;
    public Vector2 CameraPosition;
    public int WindowWidth;
    public int WindowHeight;
    public Guid PlayerGuid;
    public Camera Camera = new Camera();
}

class Settings
{
    public int GameScale = 4;
    public int UIScale = 4;
}

class GameState
{
    public List<Player> Players { get; set; } = new List<Player>();
    public World World { get; set; }
    public Settings Settings { get; set; } = new Settings();
}
