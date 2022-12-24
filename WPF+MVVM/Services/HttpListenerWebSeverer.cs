﻿using System.IO;
using WPF_MVVM.Services.Interfaces;
using WPF_MVVM.Web;

namespace WPF_MVVM.Services
{
    internal class HttpListenerWebSeverer : IWebServerService
    {
        private readonly WebServer _Server = new WebServer(8080);

        public bool Enabled { get => _Server.Enabled; set => _Server.Enabled = value; }


        public void Start() => _Server.Start();

        public void Stop() => _Server.Stop();

        public HttpListenerWebSeverer() => _Server.RequestReceived += OnRequestReceived;

        private static void OnRequestReceived(object Sender, RequestReceiverEventArgs E)
        {
            using var writer = new StreamWriter(E.Context.Response.OutputStream);
            writer.WriteLine("CV-19 Application");
        }
    }
}
