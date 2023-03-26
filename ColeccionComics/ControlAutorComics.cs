using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;
using Microsoft.EntityFrameworkCore;

namespace ColeccionComics {
    public class ControlAutorComics : ControlTable<Autor_Comic> {


        public ControlAutorComics (ModelContext context) : base(context, context.Autor_Comic) { }


        public Autor_Comic Add (int comicId, int autorId, int rolId) => Add(new Autor_Comic(comicId, autorId, rolId));
        public Autor_Comic Add (Comic comic, Autor autor, Rol rol) => Add(comic.Id, autor.Id, rol.Id);

        public override Autor_Comic[] Include () => GetDbSet().Include(x => x.Autor).Include(x => x.Comic).Include(x => x.Rol).ToArray();

        public Autor_Comic Modify (int id, int comicId, int autorId, int rolId) => Modify(id, new Autor_Comic(comicId, autorId, rolId));
        public Autor_Comic Modify(Autor_Comic r, Comic comic, Autor autor, Rol rol) => Modify(r.Id, comic.Id, autor.Id, rol.Id);

    }
}
