using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Configuration;

namespace DemoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ipHost = Dns.GetHostEntryAsync(Dns.GetHostName()).Result;
            var ipAddr = ipHost.AddressList.First(a => a.AddressFamily == AddressFamily.InterNetwork);

            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls($"http://127.0.0.1:5000")
                .Build();

            host.Run();
        }
    }
}
