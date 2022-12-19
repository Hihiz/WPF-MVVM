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

                if (ProvinceCounts is null) return default;

                var averageX = ProvinceCounts.Average(p => p.Location.X);
                var averageY = ProvinceCounts.Average(p => p.Location.Y);

                return (Point)(_Location = new Point((int)averageX, (int)averageY));
            }

            set => _Location = value;
        }

        public IEnumerable<PlaceInfo> ProvinceCounts { get; set; }
    }
}
