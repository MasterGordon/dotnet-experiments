using System.Numerics;

class Player
{
    public string name;
    public Vector2 position;
    public Vector2 movement;
}

class FrontendGameState
{
    public Vector2 movementInput;
}

class GameState
{
    public List<Player> PlayerPositions { get; set; } = new List<Player>();
}
