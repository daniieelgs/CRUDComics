using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;
using Microsoft.EntityFrameworkCore;

namespace ColeccionComics {
    public class ControlRol : ControlTable<Rol> {

        public ControlRol (ModelContext context) : base(context, context.Roles, "Nombre") { }

        public Rol Add (string nombre) => Add(new Rol(nombre));

        public override Rol [] Include () => GetDbSet().Include(x => x.Autores).ToArray();

        public Rol Modify (int id, string newNombre) => Modify(id, new Rol(newNombre));
        public Rol Modify (Rol rol, string newNombre) => Modify(rol.Id, newNombre);

    }
}
