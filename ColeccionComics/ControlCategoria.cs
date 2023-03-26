using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;
using Microsoft.EntityFrameworkCore;

namespace ColeccionComics {
    public class ControlCategoria : ControlTable<Categoria>{

        public ControlCategoria (ModelContext context) : base(context, context.Categorias, "Nombre") { }

        public Categoria Add (string nombre, string descripcion) => Add(new Categoria(nombre, descripcion));

        public override Categoria [] Include () => GetDbSet().Include(x => x.Comics).ToArray();

        public Categoria Modify (int id, string newNombre, string newDescripcion) => Modify(id, new Categoria(newNombre, newDescripcion));

        public Categoria Modify (Categoria cat, string newNombre, string newDescripcion) => Modify(cat.Id, newNombre, newDescripcion);
  
     }
}
