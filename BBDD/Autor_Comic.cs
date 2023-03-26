using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618

namespace BBDD {
    public class Autor_Comic : ITable{

        public int Id { get; set; }

        public int ComicId { get; set; }
        public int AutorId { get; set; }
        public int RolId { get; set; }

        public Comic Comic { get; set; }
        public Autor Autor { get; set; }
        public Rol Rol { get; set; }

        public Autor_Comic () { }

        public Autor_Comic (int comicId, int autorId, int rolId) {
            ComicId = comicId;
            AutorId = autorId;
            RolId = rolId;
        }

        public Autor_Comic(Comic comic, Autor autor, Rol rol) {
            Comic = comic;
            Autor = autor;
            Rol = rol;
        }

        public override string ToString () => Autor + " - " + Comic;
    }
}
