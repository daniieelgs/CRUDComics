using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;
using Microsoft.EntityFrameworkCore;

namespace ColeccionComics {
    public class ControlComic : ControlTable<Comic>{

        public ControlComic (ModelContext context) : base(context, context.Comics, "Titulo") { }

        public Comic Add (string titulo, string descripcion, DateTime fecha, int numPaginas, int categoriaId, int editorialId) => Add(new Comic(titulo, descripcion, fecha, numPaginas, categoriaId, editorialId));

        public Comic Add (string titulo, string descripcion, DateTime fecha, int numPaginas, Categoria cat, Editorial editorial) => Add(new Comic(titulo, descripcion, fecha, numPaginas, cat, editorial));
        public override Comic [] Include () => GetDbSet().Include(x => x.Categoria).Include(x => x.Autores_Comics).Include(x => x.Editorial).ToArray();

        public Comic Modify (int id, string newTitulo, string newDescr, DateTime newFecha, int newNumPag, int newCat, int editorialId) => Modify(id, new Comic(newTitulo, newDescr, newFecha, newNumPag, newCat, editorialId));
        public Comic Modify (Comic comic, string newTitulo, string newDescr, DateTime newFecha, int newNumPag, Categoria newCat, Editorial newEditorial) => Modify(comic, new Comic(newTitulo, newDescr, newFecha, newNumPag, newCat, newEditorial));
 

    }
}
