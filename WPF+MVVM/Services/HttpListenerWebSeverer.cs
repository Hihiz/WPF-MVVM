using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM.Services
{
    internal class HttpListenerWebSeverer : IWebServerService
    {
        public bool Enabled { get; set; }

        public void Start() { throw new System.NotImplementedException(); }

        public void Stop() { throw new System.NotImplementedException(); }
    }
}
