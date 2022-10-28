class Publisher
{
    private Dictionary<string, HashSet<Delegate>> subscribers =
        new Dictionary<string, HashSet<Delegate>>();
    private InteractorKind kind;

    public Publisher(InteractorKind kind)
    {
        this.kind = kind;
        this.scan();
    }

    private void scan()
    {
        var assembly = this.GetType().Assembly;
        var types = assembly.GetTypes();
        foreach (var type in types)
        {
            var attrs = type.GetCustomAttributes(typeof(Interactor), false);
            if (attrs.Length == 0)
            {
                continue;
            }
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                var attrs2 = method.GetCustomAttributes(typeof(Interaction), false);
                if (attrs2.Length == 0)
                {
                    continue;
                }
                var attr = (Interaction)attrs2[0];
                if (attr.Kind != this.kind && attr.Kind != InteractorKind.Hybrid)
                {
                    continue;
                }
                var del = Delegate.CreateDelegate(
                    typeof(Action<>).MakeGenericType(method.GetParameters()[0].ParameterType),
                    method
                );
                this.subscribe(attr.Type, del);
            }
        }
    }

    private void subscribe(string type, Delegate callback)
    {
        if (!subscribers.ContainsKey(type))
        {
            subscribers[type] = new HashSet<Delegate>();
        }
        subscribers[type].Add(callback);
    }

    public void Dump()
    {
        foreach (var pair in subscribers)
        {
            Console.WriteLine(pair.Key);
            foreach (var del in pair.Value)
            {
                Console.WriteLine(del);
            }
        }
    }
}
