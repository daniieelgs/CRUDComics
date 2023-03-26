using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    internal static class Extension {

        public static string Multiplicate (this string source, int number) => String.Concat(Enumerable.Repeat(source, number < 0 ? 0 : number));

        public static bool IsDigit (this string source) => int.TryParse(source, out _);
    }
}
