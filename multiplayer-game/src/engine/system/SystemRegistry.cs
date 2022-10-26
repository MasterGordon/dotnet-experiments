class ECSystemRegistry
{
    private HashSet<object> hybridSystems;
    private HashSet<object> clientSystems;
    private HashSet<object> serverSystems;

    public ECSystemRegistry()
    {
        hybridSystems = new HashSet<object>();
        clientSystems = new HashSet<object>();
        serverSystems = new HashSet<object>();
        object obj = new object();
    }

    public void RegisterSystem(object system, ECSystemKind kind)
    {
        this.GetSystems(kind).Add(system);
    }

    public HashSet<object> GetSystems(ECSystemKind kind) =>
        kind switch
        {
            ECSystemKind.Hybrid => hybridSystems,
            ECSystemKind.Client => clientSystems,
            ECSystemKind.Server => serverSystems,
            _ => throw new ArgumentException("Invalid ECSystemKind")
        };
}
