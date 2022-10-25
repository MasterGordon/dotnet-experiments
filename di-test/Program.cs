// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var masterService = new MasterService();
masterService.Respond();
var services = new HashSet<object>();

services.Add(new ServiceA());
services.Add(new ServiceB());

foreach (var service in services)
{
    var methods = (service.GetType().GetMethods());
    foreach (var method in methods)
    {
        Console.WriteLine(method.Name);
    }
    Console.WriteLine("-----");
    service.GetType().GetMethod("Respond")!.Invoke(service, null);
}
