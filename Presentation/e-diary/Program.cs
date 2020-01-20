using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace e_diary.WebApi
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("connectionStrings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            BuildWebHost(args).Run();

        }

        public static IWebHost BuildWebHost(string[] args)
        {
            string hostPort = string.Empty;
            try
            {
                hostPort = Configuration.GetValue<string>("HostPort", string.Empty);
                if (!string.IsNullOrEmpty(hostPort))
                {
                    hostPort = ":" + hostPort;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*" + hostPort)
                .Build();
        }
    }
}
