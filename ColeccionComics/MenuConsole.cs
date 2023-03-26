using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    internal class MenuConsole : IMenu {
        public event IMenu.Notify OnOptionSelect;
        private string cancel;
        private const string CORNER = "+", HORIZONTAL = "-", VERTICAL = "|";

        public MenuConsole (string msg = "", string cancel = "\\") {
            this.cancel = cancel;
            Console.WriteLine(msg);
        }

        public void EjecutarMenu (params string [] options) {

            Console.Write("\n");
            for(int i = 0; i < options.Length; i++) {
                Console.WriteLine($"{(i + 1)}) {options [i]}");
            }

            Console.Write("> ");

            int opt;

            int.TryParse(Console.ReadLine(), out opt);

            opt--;

            if (opt < 0 || opt >= options.Length) EjecutarMenu(options);
            else {
                Console.Write("\n");
                OnOptionSelect?.Invoke(opt);
            }
            


        }
        public void MostrarDatos (string [] titles, string [][] values) {


            int [] lenghtColumn = titles.Select((title, i) => {
                string [] valuesColumn = GetValuesColumn(values, i);
                if (valuesColumn == null || valuesColumn.Length == 0) return title.Length;
                int length = valuesColumn.MaxBy(x => x.Length)!.Length;
                return length > title.Length ? length : title.Length;
            }).ToArray();

            PrintTitleColumns(titles, lenghtColumn);
            PrintValuesColumns(values, lenghtColumn);
            int rows = values == null ? 0 : values.Length;
            Console.WriteLine((rows == 0 ? "Empty set" : $"{rows} row{(rows > 1 ? "s" : "")} in set"));

        }

        private string [] GetValuesColumn (string [] [] values, int column) => values.Select(x => x [column]).ToArray();

        private void PrintSeparatorLine (int [] lenghtColumn) {

            for (int i = 0; i < lenghtColumn.Length; i++) {
                Console.Write(CORNER + HORIZONTAL.Multiplicate(lenghtColumn [i] + 2) + (i == lenghtColumn.Length - 1 ? CORNER : ""));
            }

        }
        private void PrintValuesLine (string [] values, int [] lenghtColumn) {
            for (int i = 0; i < values.Length; i++) {
                string title = values [i];
                int length = lenghtColumn [i];
                Console.Write(VERTICAL + " " + title + " ".Multiplicate((length + 1) - title.Length) + (i == values.Length - 1 ? VERTICAL : ""));
            }
        }

        private void PrintTitleColumns (string [] titles, int [] lenghtColumn) {

            PrintSeparatorLine(lenghtColumn);
            Console.Write("\n");
            PrintValuesLine(titles, lenghtColumn);
            Console.Write("\n");
            PrintSeparatorLine(lenghtColumn);
            Console.Write("\n");

        }
        private void PrintValuesColumns (string [] [] values, int [] lengthColumn) {

            if (values.Length == 0) return;

            for(int i = 0; i < values.Length; i++) {
                PrintValuesLine(values [i], lengthColumn);
                Console.Write("\n");
            }

            PrintSeparatorLine(lengthColumn);
            Console.Write("\n");
        }

        public void MostrarDatos<T> (string [] [] values) {
            MostrarDatos(
                typeof(T)
                .GetProperties()
                .Where(x => !typeof(IEnumerable<Object>).IsAssignableFrom(x.PropertyType) /*&& !typeof(BBDD.ITable).IsAssignableFrom(x.PropertyType)*/)
                .Select(p => p.Name)
                .ToArray()
                , values);
        }

        public void MostrarDatos<T> (T [] values) {
            string [] [] rows = new string [values.Length] [];

            for(int i = 0; i < values.Length; i++) {
                T n = values [i];
                rows [i] = typeof(T)
                .GetProperties()
                .Where(x => !typeof(IEnumerable<Object>).IsAssignableFrom(x.PropertyType) /*&& !typeof(BBDD.ITable).IsAssignableFrom(x.PropertyType)*/)
                .Select(p => p.GetValue(n, null) == null ? "NULL" : p.GetValue(n, null)?.ToString())
                .ToArray()!;
            }

            MostrarDatos<T>(rows);

        }

        public string []? PedirDatos (params string [] msg) {

            string []? values = new string [msg.Length];

            for(int i = 0; i < values.Length; i++) {
                Console.Write(msg [i] +  ": ");
                values [i] = Console.ReadLine()!.Trim();
                if (values [i] == cancel) return null;
                
            }

            return values;

        }

        public string? PedirDatos (string msg) {
            string []? value = PedirDatos(new string [] { msg });

            return value == null ? null : value [0];
        }

        public bool Confirm (string msg = "Estas seguro de que quiere continuar?") {

            Console.Write(msg + " [Y/n] ");

            return Console.ReadLine()!.Trim().ToLower() == "y";
        }

        public void Error (string msg = "Fatal Error") => Console.WriteLine(msg);

        public void Info (string msg) => Console.WriteLine(msg);
        public Object Clone () => this.MemberwiseClone();

    }
}
