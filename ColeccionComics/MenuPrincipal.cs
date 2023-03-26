using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;

namespace ColeccionComics {
    public class MenuPrincipal : CRUDMenu {
        public MenuPrincipal (ComicsBBDDController bbdd, IMenu menuController) : base(bbdd, menuController) {
        }

        public override void Add () {
            string []? values = MenuController.PedirDatos("Nombre", "Descripcion");
            if (values == null) return;
            try { bbdd.Categorias.Add(values [0], values [1]); } catch (Exception e) { MenuController.Error(e.Message); }
        }
        public override void Delete () {
            Categoria? categoria = FindRegister<Categoria, string>(bbdd.Categorias, "Nombre", "categoria");
            if (categoria == null) return;

            if (MenuController.Confirm($"Borrará la categoria {categoria.Nombre} ¿Está seguro?")) {

                bbdd.Categorias.Remove(categoria);

            }
        }
        public override void Modify () {
            Categoria? categoria = FindRegister<Categoria, string>(bbdd.Categorias, "Nombre", "categoria");
            if (categoria == null) return;

            string []? values = MenuController.PedirDatos("Nombre nuevo", "Descripcion nueva");
            if (values == null) return;

            try { bbdd.Categorias.Modify(categoria, values [0], values [1]); } catch (Exception e) { MenuController.Error(e.Message); }
        }
        public override bool Other (int opt, string? msg) => msg != "Salir";
        public override void See () => MenuController.MostrarDatos<BBDD.Categoria>(bbdd.Categorias.Include());
    }
}
