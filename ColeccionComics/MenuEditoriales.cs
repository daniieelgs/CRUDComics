using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;

namespace ColeccionComics {
    internal class MenuEditoriales : CRUDMenu {
        public MenuEditoriales (ComicsBBDDController bbdd, IMenu menuController) : base(bbdd, menuController) {
        }

        public override void Add () {
            string? nombre = MenuController.PedirDatos("Nombre");
            if (nombre == null) return;
            Pais? pais = FindRegister<Pais, string>(bbdd.Paises, "Nombre", "país");
            if (pais == null) return;
            try { bbdd.Editoriales.Add(nombre, pais); } catch (Exception e) { MenuController.Error(e.Message); }
        }
        public override void Delete () {

            Editorial? editorial = FindRegister<Editorial, string>(bbdd.Editoriales, "Nombre", "editorial");
            if (editorial == null) return;

            if (MenuController.Confirm($"Borrará el pais {editorial.Nombre} ¿Está seguro?")) {

                bbdd.Editoriales.Remove(editorial);

            }
        }
        public override void Modify () {

            Editorial? editorial = FindRegister<Editorial, string>(bbdd.Editoriales, "Nombre", "editorial");
            if (editorial == null) return;

            string? nombre = MenuController.PedirDatos("Nombre nuevo");
            if (nombre == null) return;

            Pais? pais = FindRegister<Pais, string>(bbdd.Paises, "Nombre", "país nuevo");
            if (pais == null) return;

            try { bbdd.Editoriales.Modify(editorial, nombre, pais); } catch (Exception e) { MenuController.Error(e.Message); }
        }
        public override bool Other (int opt, string? msg) => msg != "Salir";
        public override void See () => MenuController.MostrarDatos<BBDD.Editorial>(bbdd.Editoriales.Include());

    }
}
