using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;

namespace ColeccionComics {
    public class MenuRelacion : CRUDMenu {
        public MenuRelacion (ComicsBBDDController bbdd, IMenu menuController) : base(bbdd, menuController) {
        }

        public override void Add () {
            Comic? comic = FindRegister<Comic, string>(bbdd.Comics, "Titulo", "comic");
            if (comic == null) return;
            Autor? autor = FindRegister<Autor, string>(bbdd.Autores, "Nombre", "autor");
            if (autor == null) return;
            Rol? rol = FindRegister<Rol, string>(bbdd.Roles, "Nombre", "rol");
            if (rol == null) return;

            bbdd.AutorComics.Add(comic, autor, rol);
        }
        public override void Delete () {
            Autor_Comic? relacion = FindRegister<Autor_Comic>(bbdd.AutorComics, "asignacion");
            if (relacion == null) return;

            if (MenuController.Confirm($"Borrará la nacionalidad {relacion.Id} ¿Está seguro?")) {
                bbdd.AutorComics.Remove(relacion);
            }
        }
        public override void Modify () {
            Autor_Comic? relacion = FindRegister<Autor_Comic>(bbdd.AutorComics, "asignacion Autor-Comic");
            if (relacion == null) return;
            Autor? autor = FindRegister<Autor, string>(bbdd.Autores, "Nombre", "nuevo autor");
            if (autor == null) return;
            Comic? comic = FindRegister<Comic, string>(bbdd.Comics, "Titulo", "nuevo comic");
            if (comic == null) return;
            Rol? rol = FindRegister<Rol, string>(bbdd.Roles, "Nombre", "nuevo rol");
            if (rol == null) return;

            bbdd.AutorComics.Modify(relacion, comic, autor, rol);
        }
        public override bool Other (int opt, string? msg) => msg != "Salir";
        public override void See () => MenuController.MostrarDatos<BBDD.Autor_Comic>(bbdd.AutorComics.Include());
    }
}
