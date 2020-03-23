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
using SharpDX.XInput;
using System.Runtime.InteropServices;

namespace RemoteMusicController
{
    public class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
         
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        public static string hostadress { get; } = File.ReadAllText("Hosting.conf");
        public static void Main(string[] args)
        {
            ShowWindow(GetConsoleWindow(), 0); // Скрыть.
            Task.Run(()=>GamepadMediaControllerStart());
            var host = BuildWebHost(args);
            host.Run();

        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseUrls(hostadress)//, "http://*:81")//ADD dns?
                .UseStartup<Startup>()
                .UseKestrel()
                .Build();
        public static void GamepadMediaControllerStart()
        {
            while (true)
            {
                var controller = new Controller(UserIndex.One);
                if (controller != null)
                {
                    if (controller.IsConnected)
                    {
                        var state = controller.GetState();
                        if (state.Gamepad.Buttons == GamepadButtonFlags.RightThumb)
                        {
                            KButton.List.FirstOrDefault(x => x.Button == Button.Next).Press();
                            System.Threading.Thread.Sleep(400);
                        }
                    }
                }
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
