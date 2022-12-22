using System.Collections.Generic;
using System.Windows.Input;
using WPF_MVVM.Infrastructure.Commands;
using WPF_MVVM.Interfaces;
using WPF_MVVM.Models;
using WPF_MVVM.Services;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    internal class CountriesStatisticViewModel : ViewModel
    {
        private readonly IDataService _DataService;
        public MainWindowViewModel MainModel { get; internal set; }


        #region Contries : IEnumerable<CountryInfo> - Статистика по странам

        /// <summary>Статистика по странам</summary>
        private IEnumerable<CountryInfo> _Countries;

        /// <summary>Статистика по странам</summary>
        public IEnumerable<CountryInfo> Countries
        {
            get => _Countries;
            private set => Set(ref _Countries, value);
        }

        #endregion

        #region SelectedCountry : CountryInfo - Выбранная страна

        /// <summary>Выбранная страна</summary>
        private CountryInfo _SelectedCountry;

        /// <summary>Выбранная страна</summary>
        public CountryInfo SelectedCountry { get => _SelectedCountry; set => Set(ref _SelectedCountry, value); }

        #endregion

        #region Команды

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _DataService.GetData();
        }

        #endregion

        ///// <summary>Отладочный конструктор, используемый в процессе разработки в визуальном дизайнере</summary>
        //public CountriesStatisticViewModel() : this(null)
        //{
        //    if (!App.IsDesignMode)
        //        throw new InvalidOperationException("Вызов конструктора, не предназначенного для использования в обычном режиме");

        //    _Countries = Enumerable.Range(1, 10)
        //       .Select(i => new CountryInfo
        //       {
        //           Name = $"Country {i}",
        //           Provinces = Enumerable.Range(1, 10).Select(j => new PlaceInfo
        //           {
        //               Name = $"Province {i}",
        //               Location = new Point(i, j),
        //               Counts = Enumerable.Range(1, 10).Select(k => new ConfirmedCount
        //               {
        //                   Date = DateTime.Now.Subtract(TimeSpan.FromDays(100 - k)),
        //                   Count = k
        //               }).ToArray()
        //           }).ToArray()
        //       }).ToArray();
        //}

        public CountriesStatisticViewModel(IDataService DataService)
        {
            _DataService = DataService;

            //var data = App.Host.Services.GetRequiredService<IDataService>();

            //var are_ref_equal = ReferenceEquals(DataService, data);

            //using (var scope = App.Host.Services.CreateScope())
            //{
            //    var data2 = scope.ServiceProvider.GetRequiredService<IDataService>();
            //    var are_ref_equal2 = ReferenceEquals(DataService, data2);
            //    var are_ref_equal3 = ReferenceEquals(data, data2);
            //}

            #region Команды

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

            #endregion

        }

        //public CountriesStatisticViewModel(MainWindowViewModel MainModel)
        //{
        //    this.MainModel = MainModel;

        //    _DataService = new DataService();

        //    #region Команды

        //    RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

        //    #endregion
        //}
    }
}
