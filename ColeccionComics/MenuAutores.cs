using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;

namespace ColeccionComics {
    public class MenuAutores : CRUDMenu {
        public MenuAutores (ComicsBBDDController bbdd, IMenu menuController) : base(bbdd, menuController) {
        }

        public override void Add () {
            string? nombre = MenuController.PedirDatos("Nombre");
            if (nombre == null) return;

            int agnoNacimiento = 0;

            do {
                string? strAgno = MenuController.PedirDatos("Año de nacimiento");
                if (strAgno == null) return;
                int.TryParse(strAgno, out agnoNacimiento);
            } while (agnoNacimiento < 1);

            Nacionalidad? nacion = FindRegister<Nacionalidad, string>(bbdd.Nacionalidades, "Nombre", "nacionalidad");
            if (nacion == null) return;

            bbdd.Autores.Add(nombre, agnoNacimiento, nacion);
        }
        public override void Delete () {

            Autor? autor = FindRegister<Autor, string>(bbdd.Autores, "Nombre", "autor");
            if (autor == null) return;

            if (MenuController.Confirm($"Borrará la nacionalidad {autor.Nombre} ¿Está seguro?")) {
                bbdd.Autores.Remove(autor);
            }

        }
        public override void Modify () {

            Autor? autor = FindRegister<Autor, string>(bbdd.Autores, "Nombre", "autor");
            if (autor == null) return;

            string? nombre = MenuController.PedirDatos("Nombre nuevo");
            if (nombre == null) return;

            int agno = 0;

            do {
                string? strAgno = MenuController.PedirDatos("Año de nacimiento nuevo");
                if (strAgno == null) return;
                int.TryParse(strAgno, out agno);
            } while (agno < 1);

            Nacionalidad? nacion = FindRegister<Nacionalidad, string>(bbdd.Nacionalidades, "Nombre", "nueva nacionalidad");
            if (nacion == null) return;

            bbdd.Autores.Modify(autor, nombre, agno, nacion);
        }
        public override bool Other (int opt, string? msg) => msg != "Salir";
        public override void See () => MenuController.MostrarDatos<BBDD.Autor>(bbdd.Autores.Include());
    }
}
