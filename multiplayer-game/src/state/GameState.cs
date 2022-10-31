using System.Numerics;

class Player
{
    public string name;
    public Vector2 position;
    public Vector2 movement;
    public Guid guid;
}

class FrontendGameState
{
    public Vector2 MovementInput;
    public Vector2 CameraPosition;
    public int WindowWidth;
    public int WindowHeight;
    public Guid PlayerGuid;
}

class Settings
{
    public int GameScale = 4;
    public int UIScale = 4;
}

class GameState
{
    public List<Player> PlayerPositions { get; set; } = new List<Player>();
    public World World { get; set; }
    public Settings Settings { get; set; } = new Settings();
}
