using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM.Interfaces;
using WPF_MVVM.Services.Interfaces;

namespace WPF_MVVM.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            //services.AddTransient<IDataService, DataService>();
            //services.AddScoped<IDataService, DataService>();

            services.AddTransient<IAsyncDataService, AsyncDataService>();
            services.AddTransient<IWebServerService, HttpListenerWebSeverer>();

            return services;
        }
    }
}
