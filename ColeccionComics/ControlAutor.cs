using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;
using Microsoft.EntityFrameworkCore;

namespace ColeccionComics {
    public class ControlAutor : ControlTable<Autor> {

        public ControlAutor (ModelContext context) : base(context, context.Autores) { }

        public Autor Add (string nombre, int agnoNacimiento, int idNacionalidad) => Add(new Autor(nombre, agnoNacimiento, idNacionalidad));
        public Autor Add (string nombre, int agnoNacimiento, Nacionalidad nac) => Add(nombre, agnoNacimiento, nac.Id);
        public override Autor[] Include () => GetDbSet().Include(x => x.Nacionalidad).Include(x => x.Autores_Comics).ToArray();

        public Autor Modify (int id, string newNombre, int newAgnoNacimiento, int newIdNacion) => Modify(id, new Autor(newNombre, newAgnoNacimiento, newIdNacion));
        public Autor Modify (Autor autor, string newNombre, int newAgnoNacimiento, Nacionalidad nac) => Modify(autor.Id, newNombre, newAgnoNacimiento, nac.Id);

    }
}
