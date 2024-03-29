﻿using Microsoft.Extensions.DependencyInjection;

namespace WPF_MVVM.ViewModels
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CountriesStatisticViewModel>();
            services.AddSingleton<WebServerViewModel>();

            return services;
        }
    }
}
