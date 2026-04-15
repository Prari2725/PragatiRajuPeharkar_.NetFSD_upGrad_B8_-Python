using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices; // add this
namespace WorkerService1;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .UseWindowsService() // Important line
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}

