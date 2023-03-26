using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;
using Microsoft.EntityFrameworkCore;

namespace ColeccionComics {
    public class ControlEditorial : ControlTable<Editorial> {
        public ControlEditorial (ModelContext context) : base(context, context.Editoriales) { }

        public override Editorial [] Include () => GetDbSet().Include(x => x.Pais).Include(x => x.Comics).ToArray();

        public Editorial Add (string nombre, int paisId) => Add(new Editorial(nombre, paisId));
        public Editorial Add (string nombre, Pais pais) => Add(new Editorial(nombre, pais));

        public Editorial Modify (int id, string newNombre, int newPaisId) => Modify(id, new Editorial(newNombre, newPaisId));
        public Editorial Modify (Editorial editorial, string newNombre, Pais newPais) => Modify(editorial, new Editorial(newNombre, newPais));

    }
}
