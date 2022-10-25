enum ECSystemKind
{
    Client,
    Server,
    Hybrid
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
class ECSystem : Attribute
{
    public ECSystemKind Kind;

    public ECSystem(ECSystemKind kind)
    {
        this.Kind = kind;
    }
}
