class MasterService : Service
{
    private List<Service> services = new List<Service>();

    public MasterService()
    {
        typeof(MasterService).Assembly.GetTypes()
            .Where(t => t.GetCustomAttributes(typeof(ServiceAttribute), false).Length > 0)
            // .Where(t => t.IsSubclassOf(typeof(Service)))
            .ToList()
            .ForEach(t => services.Add((Service)Activator.CreateInstance(t)!));
    }

    public void Respond()
    {
        Console.WriteLine($"Servic Count: {services.Count}");
        services.ForEach(s => s.Respond());
    }
}
