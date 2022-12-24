using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM.Web;

namespace WPF_MVVMConsole
{
    internal static class WebServerTest
    {
        public static void Run()
        {
            var server = new WebServer(8080);
            server.RequestReceived += OnRequestReceived;

            server.Start();

            Console.WriteLine("Сервер запущен!");
            Console.ReadLine();
        }

        private static void OnRequestReceived(object? Sender, RequestReceiverEventArgs E)
        {
            var context = E.Context;

            Console.WriteLine("Connection {0}", context.Request.UserHostAddress);

            using var writer = new StreamWriter(context.Response.OutputStream);
            writer.WriteLine("Hello from Test Web Server!!!");
        }
    }
}
