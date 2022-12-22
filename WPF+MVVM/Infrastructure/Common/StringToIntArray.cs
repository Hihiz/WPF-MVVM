using System;
using System.Linq;
using System.Windows.Markup;

namespace WPF_MVVM.Infrastructure.Common
{
    [MarkupExtensionReturnType(typeof(int[]))]
    internal class StringToIntArray : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider sp) =>
            Str.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
               .DefaultIfEmpty()
               .Select(int.Parse)
               .ToArray();

        [ConstructorArgument("Str")]
        public string Str { get; set; }

        public char Separator { get; set; } = ';';

        public StringToIntArray() { }

        public StringToIntArray(string Str) => this.Str = Str;
    }
}
