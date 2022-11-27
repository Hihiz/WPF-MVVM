using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace WPF_MVVMConsole
{
    internal class Program
    {
        // заболеваемость cov19
        private const string data_url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var data_stream = GetDataStream().Result;
            using var data_reader = new StreamReader(data_stream);

            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line;
            }
        }

        // Парсинг сторки с всеми датами
        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();



        static void Main(string[] args)
        {
            //var web_client = new WebClient();

            //var client = new HttpClient();

            ////Получить последний элемент в массиве
            //string[] items = new string[10] { "1", "2", "3", "4", "5", "6", "Helo World", "7", "Helo", "last" };
            //string lastItem = items[^1];
            ////предпоследний элемент
            //string prev_last_item = items[^2]; 

            //var response = client.GetAsync(data_url).Result;
            //var csv_str = response.Content.ReadAsStringAsync().Result;

            //foreach (var data_line in GetDataLines())
            //    Console.WriteLine(data_line);

            var dates = GetDates();

            Console.WriteLine(string.Join("\r\n", dates));

            Console.ReadLine();
        }
    }
}