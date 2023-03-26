using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;

namespace ColeccionComics {
    internal class MenuEstadisticas : IActionMenu {

        private ComicsBBDDController bbdd;
        private IMenu MenuController;

        public MenuEstadisticas (ComicsBBDDController bbdd, IMenu MenuController) {
            this.bbdd = bbdd;
            this.MenuController = MenuController;
        }

        public bool Select (int opt, string? msg) {
            switch (opt) {
                case 0: ComicsXCategoria(); return true;
                case 1: ComicsXAutor(); return true;
                case 2: TopNumPag(5); return true;
                case 3: AutoresXNacion(); return true;
                case 4: return false;
                default: throwArgumentException(opt); return false;
            }
        }

        private void ComicsXCategoria () {

            Categoria [] categorias = bbdd.Categorias.Include();

            string [] [] value = new string [categorias.Length] [];

            for (int i = 0; i < categorias.Length; i++) {

                value [i] = new string [] { categorias [i].Nombre, categorias [i].Comics.Count().ToString() };

            }

            MenuController.MostrarDatos(new string [] { "Categoría", "Nº comics" }, value);

        }

        private void ComicsXAutor () {
            Autor [] autores = bbdd.Autores.Include();

            string [] [] values = new string [autores.Length] [];

            for (int i = 0; i < values.Length; i++) {

                values [i] = new string [] { autores [i].Nombre, autores [i].Autores_Comics.DistinctBy(x => x.ComicId).Count().ToString() };

            }

            MenuController.MostrarDatos(new string [] { "Autor", "Nº comics" }, values);
        }

        private void TopNumPag (int top) => MenuController.MostrarDatos<BBDD.Comic>(bbdd.Comics.GetAll().OrderByDescending(x => x.NumeroPaginas).Take(top).ToArray());

        private void AutoresXNacion () {

            Nacionalidad [] naciones = bbdd.Nacionalidades.Include();

            string [] [] values = new string [naciones.Length] [];

            for (int i = 0; i < values.Length; i++) {
                values [i] = new string [] { naciones [i].Nombre, naciones [i].Autores.Count().ToString() };
            }

            MenuController.MostrarDatos(new string [] { "Nacionalidad", "Nº autores" }, values);

        }
        private void throwArgumentException (int opt) => throw new ArgumentException($"Option {opt} not found");

    }
}
