using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WEB_API_Task;


namespace WEB_API_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                .Build();
    }
}
