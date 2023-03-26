using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;

namespace ColeccionComics {
    public class MenuNacionalidades : CRUDMenu {
        public MenuNacionalidades (ComicsBBDDController bbdd, IMenu menuController) : base(bbdd, menuController) {
        }

        public override void Add () {
            string? nombre = MenuController.PedirDatos("Nombre");
            if (nombre == null) return;
            Pais? pais = FindRegister<Pais, string>(bbdd.Paises, "Nombre", "pais");
            if (pais == null) return;
            try { bbdd.Nacionalidades.Add(nombre, pais); } catch (Exception e) { MenuController.Error(e.Message); }
        }
        public override void Delete () {
            Nacionalidad? nacion = FindRegister<Nacionalidad, string>(bbdd.Nacionalidades, "Nombre", "nacionalidad");
            if (nacion == null) return;

            if (MenuController.Confirm($"Borrará la nacionalidad {nacion.Nombre} ¿Está seguro?")) {

                bbdd.Nacionalidades.Remove(nacion);

            }
        }
        public override void Modify () {
            Nacionalidad? nacion = FindRegister<Nacionalidad, string>(bbdd.Nacionalidades, "Nombre", "nacionalidad");
            if (nacion == null) return;
            string? nombre = MenuController.PedirDatos("Nombre nuevo");
            if (nombre == null) return;
            Pais? pais = FindRegister<Pais, string>(bbdd.Paises, "Nombre", "pais");
            if (pais == null) return;

            try { bbdd.Nacionalidades.Modify(nacion, nombre, pais.Id); } catch (Exception e) { MenuController.Error(e.Message); }

        }
        public override bool Other (int opt, string? msg) => msg != "Salir";
        public override void See () => MenuController.MostrarDatos<BBDD.Nacionalidad>(bbdd.Nacionalidades.Include());
    }
}
