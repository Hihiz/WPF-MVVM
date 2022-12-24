namespace WPF_MVVM.Services.Interfaces
{
    internal interface IWebServerService
    {
        bool Enabled { get; set; }

        void Start();

        void Stop();
    }
}
