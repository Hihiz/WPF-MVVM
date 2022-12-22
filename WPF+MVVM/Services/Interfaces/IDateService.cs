using System.Collections.Generic;
using WPF_MVVM.Models;

namespace WPF_MVVM.Interfaces
{
    internal interface IDataService
    {
        IEnumerable<CountryInfo> GetData();
    }
}
