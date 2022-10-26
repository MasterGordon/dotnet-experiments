using System.Numerics;

readonly struct MovePacket
{
    readonly public string type = "move";
    readonly public string playerName;
    readonly public Vector2 movement;

    public MovePacket(string playerName, Vector2 movement)
    {
        this.playerName = playerName;
        this.movement = movement;
    }
}

readonly struct ConnectPacket
{
    public readonly string type = "connect";
    public readonly string playerName;

    public ConnectPacket(string playerName)
    {
        this.playerName = playerName;
    }
}
