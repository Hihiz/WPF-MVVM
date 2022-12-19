﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_MVVM.Infrastructure.Converters
{
    internal abstract class Converter : IValueConverter
    {
        public abstract object Convert(object v, Type t, object p, CultureInfo c);

        public virtual object ConvertBack(object v, Type t, object p, CultureInfo c) =>
            throw new NotSupportedException("Обратное преобразование не поддерживается");
    }
}