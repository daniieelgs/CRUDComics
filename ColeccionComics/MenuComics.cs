using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;

namespace ColeccionComics {
    public class MenuComics : CRUDMenu {
        public MenuComics (ComicsBBDDController bbdd, IMenu menuController) : base(bbdd, menuController) {
        }

        public override void Add () {

            string []? values = MenuController.PedirDatos("Titulo", "Descripcion");
            if (values == null) return;

            bool parse = false;

            int numPag = 0;
            DateTime fecha = new DateTime();

            do {

                string? fechaStr = MenuController.PedirDatos("Fecha [MM/dd/aaaa]");

                if (fechaStr == null) return;

                try {

                    fecha = Convert.ToDateTime(fechaStr);

                    parse = true;

                } catch (Exception) { MenuController.Error("Datos Erroneos"); }

            } while (!parse);

            do int.TryParse(MenuController.PedirDatos("Numero páginas"), out numPag); while (numPag < 1);

            Categoria? categoria = FindRegister<Categoria, string>(bbdd.Categorias, "Nombre", "categoria");
            if (categoria == null) return;

            Editorial? editorial = FindRegister<Editorial, string>(bbdd.Editoriales, "Nombre", "editorial");
            if (editorial == null) return;

            bbdd.Comics.Add(values [0], values [1], fecha, numPag, categoria, editorial);
        }
        public override void Delete () {
            Comic? comic = FindRegister<Comic, string>(bbdd.Comics, "Titulo", "comic");
            if (comic == null) return;

            if (MenuController.Confirm($"Borrará la nacionalidad {comic.Titulo} ¿Está seguro?")) {

                bbdd.Comics.Remove(comic);

            }
        }
        public override void Modify () {

            Comic? comic = FindRegister<Comic, string>(bbdd.Comics, "Nombre", "comic");
            if (comic == null) return;

            string []? values = MenuController.PedirDatos("Titulo", "Descripcion");
            if (values == null) return;

            bool parse = false;

            int numPag = 0;
            DateTime fecha = new DateTime();

            do {

                string? fechaStr = MenuController.PedirDatos("Fecha [MM/dd/aaaa]");
                if (fechaStr == null) return;

                try {

                    fecha = Convert.ToDateTime(fechaStr);

                    parse = true;

                } catch (Exception) { MenuController.Error("Datos Erroneos"); }

            } while (!parse);


            do { int.TryParse(MenuController.PedirDatos("Numero páginas"), out numPag); } while (numPag < 1);

            Categoria? categoria = FindRegister<Categoria, string>(bbdd.Categorias, "Titulo", "categoria");
            if (categoria == null) return;

            Editorial? editorial = FindRegister<Editorial, string>(bbdd.Editoriales, "Nombre", "editorial");
            if (editorial == null) return;

            bbdd.Comics.Modify(comic, values [0], values [1], fecha, numPag, categoria, editorial);
        }
        public override bool Other (int opt, string? msg) => msg != "Salir";
        public override void See () => MenuController.MostrarDatos<BBDD.Comic>(bbdd.Comics.Include());
    }
}
