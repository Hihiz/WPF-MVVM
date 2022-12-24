using System;
using System.Threading;
using WPF_MVVM.Interfaces;

namespace WPF_MVVM.Services
{
    internal class AsyncDataService : IAsyncDataService
    {
        private const int __SleepTime = 7000;

        public string GetResult(DateTime Time)
        {
            Thread.Sleep(__SleepTime);

            return $"Result value {Time}";
        }
    }
}
