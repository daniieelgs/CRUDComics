using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;
using Microsoft.EntityFrameworkCore;
using ColeccionComics;

namespace ColeccionComics {
    public class ComicsBBDDController {

        private ModelContext context;

        public ModelContext Context { get => context; }

        public readonly ControlCategoria Categorias;
        public readonly ControlAutor Autores;
        public readonly ControlComic Comics;
        public readonly ControlRol Roles;
        public readonly ControlNacionalidad Nacionalidades;
        public readonly ControlAutorComics AutorComics;
        public readonly ControlPais Paises;
        public readonly ControlEditorial Editoriales;

        public ComicsBBDDController () {
            context = new ModelContext();

            Categorias = new ControlCategoria(context);
            Autores = new ControlAutor(context);
            Comics = new ControlComic(context);
            Roles = new ControlRol(context);
            Nacionalidades = new ControlNacionalidad(context);
            AutorComics = new ControlAutorComics(context);
            Paises = new ControlPais(context);
            Editoriales = new ControlEditorial(context);
        }

    }
}
