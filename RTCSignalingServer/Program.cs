using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RTCSignalingServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5001")
                .Build();
        }
    }
}