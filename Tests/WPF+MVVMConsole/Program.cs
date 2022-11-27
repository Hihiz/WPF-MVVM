using System.Net;
using System.Runtime.CompilerServices;

namespace WPF_MVVMConsole
{
    internal class Program
    {
        private const string data_url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        static void Main(string[] args)
        {
            //var web_client = new WebClient();

            var client = new HttpClient();

            ////Получить последний элемент в массиве
            //string[] items = new string[10] { "1", "2", "3", "4", "5", "6", "Helo World", "7", "Helo", "last" };
            //string lastItem = items[^1];
            ////предпоследний элемент
            //string prev_last_item = items[^2];

            var response = client.GetAsync(data_url).Result;
            var csv_str = response.Content.ReadAsStringAsync().Result;
            Console.ReadLine();

        }
    }
}