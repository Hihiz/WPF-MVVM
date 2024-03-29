﻿using System.Windows.Input;
using WPF_MVVM.Infrastructure.Commands;
using WPF_MVVM.Services.Interfaces;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    internal class WebServerViewModel : ViewModel
    {
        private readonly IWebServerService _Server;

        #region Enabled

        public bool Enabled
        {
            get => _Server.Enabled;
            set
            {
                _Server.Enabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region StartCommand

        private ICommand _StartCommand;

        public ICommand StartCommand => _StartCommand
            ??= new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);

        private bool CanStartCommandExecute(object p) => !Enabled;

        private void OnStartCommandExecuted(object p)
        {
            _Server.Start();
            OnPropertyChanged(nameof(Enabled));
        }

        #endregion

        #region StopCommand

        private ICommand _StopCommand;

        public ICommand StopCommand => _StopCommand
            ??= new LambdaCommand(OnStopCommandExecuted, CanStopCommandExecute);

        private bool CanStopCommandExecute(object p) => Enabled;

        private void OnStopCommandExecuted(object p)
        {
            _Server.Stop();
            OnPropertyChanged(nameof(Enabled));
        }

        #endregion

        public WebServerViewModel(IWebServerService Server) => _Server = Server;
    }
}
