using System.Collections.Generic;
using System.Drawing;

namespace WPF_MVVM.Models
{
    internal class PlaceInfo
    {

        public string Name { get; set; }
        public virtual Point Location { get; set; }

        public IEnumerable<ConfirmedCount> Counts { get; set; }

        public override string ToString() => $"{Name}({Location})";
    }
}
