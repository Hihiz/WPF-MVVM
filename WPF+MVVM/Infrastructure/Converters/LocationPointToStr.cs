﻿using System;
using System.Drawing;
using System.Globalization;

namespace WPF_MVVM.Infrastructure.Converters
{
    internal class LocationPointToStr : Converter
    {
        public override object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (!(value is Point point)) return null;

            return $"Lat:{point.X};Lon:{point.Y}";
        }

        public override object ConvertBack(object value, Type y, object p, CultureInfo c)
        {
            if (!(value is string str)) return null;

            var components = str.Split(';');
            var lat_str = components[0].Split(':')[1];
            var lon_str = components[1].Split(':')[1];

            var lat = double.Parse(lat_str);
            var lon = double.Parse(lon_str);

            return new Point((int)lat, (int)lon);
        }
    }
}
