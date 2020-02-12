using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace RemoteMusicController
{
    public class Program
    {
        public static string hostadress { get; } = File.ReadAllText("Hosting.conf");
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            host.Run();

        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseUrls(hostadress)//, "http://*:81")//ADD dns?
                .UseStartup<Startup>()
                .UseKestrel()
                .Build();
    }
}
