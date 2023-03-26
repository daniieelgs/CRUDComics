using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;

namespace ColeccionComics {
    internal class MenuPaises : CRUDMenu {
        public MenuPaises (ComicsBBDDController bbdd, IMenu menuController) : base(bbdd, menuController) {
        }

        public override void Add () {
            string? nombre = MenuController.PedirDatos("Nombre");
            if (nombre == null) return;
            try { bbdd.Paises.Add(nombre); } catch (Exception e) { MenuController.Error(e.Message); }
        }
        public override void Delete () {

            Pais? pais = FindRegister<Pais, string>(bbdd.Paises, "Nombre", "pais");
            if (pais == null) return;

            if (MenuController.Confirm($"Borrará el pais {pais.Nombre} ¿Está seguro?")) {

                bbdd.Paises.Remove(pais);

            }
        }
        public override void Modify () {

            Pais? pais = FindRegister<Pais, string>(bbdd.Paises, "Nombre", "pais");
            if (pais == null) return;

            string? nombre = MenuController.PedirDatos("Nombre nuevo");
            if (nombre == null) return;

            try { bbdd.Paises.Modify(pais, nombre); } catch (Exception e) { MenuController.Error(e.Message); }
        }
        public override bool Other (int opt, string? msg) => msg != "Salir";
        public override void See () => MenuController.MostrarDatos<BBDD.Pais>(bbdd.Paises.Include());
    }
}
