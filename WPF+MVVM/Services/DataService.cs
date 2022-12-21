using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using WPF_MVVM.Models;

namespace WPF_MVVM.Services
{
    internal class DataService
    {
        private const string _DataSourceAddress = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                _DataSourceAddress, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var dataStream = (SynchronizationContext.Current is null ? GetDataStream() : Task.Run(GetDataStream)).Result;
            using var dataReader = new StreamReader(dataStream);

            while (!dataReader.EndOfStream)
            {
                var line = dataReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line
                    .Replace("Korea,", "Korea -")
                    .Replace("Bonaire,", "Bonaire -");
            }
        }

        // Парсинг сторки с всеми датами
        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',') /*Split разбивает по запятой*/
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        //Извлечь информацию о каждой стране
        private static IEnumerable<(string Province, string Country, (double Lat, double Lon) Place, int[] Counts)> GetCountriesData()
        {
            var lines = GetDataLines()
               .Skip(1)
               .Select(line => line.Split(','));

            foreach (var row in lines)
            {
                var province = row[0].Trim(); 
                var countryName = row[1].Trim(' ', '"');
                var latitude = double.Parse(row[2], CultureInfo.InvariantCulture);
                var longitude = double.Parse(row[3], CultureInfo.InvariantCulture);
                var counts = row.Skip(4).Select(int.Parse).ToArray();

                yield return (province, countryName, (latitude, longitude), counts);
            }
        }

        public IEnumerable<CountryInfo> GetData()
        {
            var dates = GetDates();

            var data = GetCountriesData().GroupBy(d => d.Country);

            foreach (var countryШnfo in data)
            {
                var country = new CountryInfo
                {
                    Name = countryШnfo.Key,
                    Provinces = countryШnfo.Select(c => new PlaceInfo
                    {
                        Name = c.Province,
                        Location = new Point((int)c.Place.Lat, (int)c.Place.Lon),
                        Counts = dates.Zip(c.Counts, (date, count) => new ConfirmedCount { Date = date, Count = count })
                    })
                };
                yield return country;
            }

        }
    }
}
