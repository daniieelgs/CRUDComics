using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;
using Microsoft.EntityFrameworkCore;

namespace ColeccionComics {
    public class ControlNacionalidad : ControlTable<Nacionalidad>{

        public ControlNacionalidad (ModelContext context) : base(context, context.Nacionalidades, "Nombre") { }

        public Nacionalidad Add (string nombre, int paisId) => Add(new Nacionalidad(nombre, paisId));
        public Nacionalidad Add (string nombre, Pais pais) => Add(new Nacionalidad(nombre, pais));

        public override Nacionalidad [] Include () => GetDbSet().Include(x => x.Autores).Include(x => x.Pais).ToArray();

        public Nacionalidad Modify (int id, string newNombre, int newPaisId) => Modify(id, new Nacionalidad(newNombre, newPaisId));
        public Nacionalidad Modify (Nacionalidad nac, string newNombre, int newPais) => Modify(nac.Id, newNombre, newPais);


    }
}
