using WPF_MVVM.Services;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    internal class CountriesStatisticViewModel : ViewModel
    {
        private DataService _DataService;

        private MainWindowViewModel MainModel { get; }



        public CountriesStatisticViewModel(MainWindowViewModel MainModel)
        {
            MainModel = MainModel;

            _DataService = new DataService();
        }
    }
}
