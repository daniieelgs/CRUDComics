using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;

namespace ColeccionComics {
    public class MenuRoles : CRUDMenu {
        public MenuRoles (ComicsBBDDController bbdd, IMenu menuController) : base(bbdd, menuController) {
        }

        public override void Add () {
            string? nombre = MenuController.PedirDatos("Nombre");
            if (nombre == null) return;
            try { bbdd.Roles.Add(nombre); } catch (Exception e) { MenuController.Error(e.Message); }
        }
        public override void Delete () {

            Rol? rol = FindRegister<Rol, string>(bbdd.Roles, "Nombre", "rol");
            if (rol == null) return;

            if (MenuController.Confirm($"Borrará el rol {rol.Nombre} ¿Está seguro?")) {

                bbdd.Roles.Remove(rol);

            }
        }
        public override void Modify () {

            Rol? rol = FindRegister<Rol, string>(bbdd.Roles, "Nombre", "rol");
            if (rol == null) return;

            string? nombre = MenuController.PedirDatos("Nombre nuevo");
            if (nombre == null) return;

            try { bbdd.Roles.Modify(rol, nombre); } catch (Exception e) { MenuController.Error(e.Message); }

        }

        public override bool Other (int opt, string? msg) => msg != "Salir";
        public override void See () => MenuController.MostrarDatos<BBDD.Rol>(bbdd.Roles.Include());
    }
}
