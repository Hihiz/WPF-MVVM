using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WPF_MVVM.Models
{
    internal class CountryInfo : PlaceInfo
    {
        private Point _Location;
        public override Point Location
        {
            get
            {
                if (_Location != null)
                    return _Location;

                if (Provinces is null) return default;

                var averageX = Provinces.Average(p => p.Location.X);
                var averageY = Provinces.Average(p => p.Location.Y);

                return (Point)(_Location = new Point((int)averageX, (int)averageY));
            }

            set => _Location = value;
        }

        public IEnumerable<PlaceInfo> Provinces { get; set; }

        private IEnumerable<ConfirmedCount> _Counts;

        public override IEnumerable<ConfirmedCount> Counts
        {
            get
            {
                if (_Counts != null) return _Counts;

                var points_count = Provinces.FirstOrDefault()?.Counts?.Count() ?? 0;
                if (points_count == 0) return Enumerable.Empty<ConfirmedCount>();

                var province_points = Provinces.Select(p => p.Counts.ToArray()).ToArray();

                var points = new ConfirmedCount[points_count];
                foreach (var province in province_points)
                    for (var i = 0; i < points_count; i++)
                    {
                        if (points[i].Date == default)
                            points[i] = province[i];
                        else
                            points[i].Count += province[i].Count;
                    }

                return _Counts = points;
            }
            set => _Counts = value;
        }
    }
}
