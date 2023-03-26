using BBDD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    public class ControlPais : ControlTable<Pais> {

        public ControlPais (ModelContext context) : base(context, context.Paises, "Nombre") { }

        public override Pais [] Include () => base.GetDbSet().Include(x => x.Nacionalidades).Include(x => x.Editoriales).ToArray();

        public Pais Add (string nombre) => Add(new Pais(nombre));

        public Pais Modify (int id, string newNombre) => Modify(id, new Pais(newNombre));
        public Pais Modify (Pais pais, string newNombre) => Modify(pais, new Pais(newNombre));
    }
}
