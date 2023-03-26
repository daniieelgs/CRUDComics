using BBDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    internal class CRUDComicsController {

        //INDEX UNIQUE CONJUNTA PARA AUTOR_COMIC (COMIC, AUTOR, ROL)

        private IMenu MenuController;

        private delegate void EjecutarMenu();

        private ComicsBBDDController bbdd;

        public CRUDComicsController (IMenu menuController) {

            MenuController = menuController;
            bbdd = new ComicsBBDDController();

        
            MenuCreator menu = new MenuCreator((IMenu) MenuController.Clone(), new MenuPrincipal(bbdd, menuController) ,"Principal");

            MenuCreator menuRoles = new MenuCreator((IMenu) MenuController.Clone(), new MenuRoles(bbdd, menuController), "Roles");
            menuRoles.AddOptions(CreateCRUDMenu("rol"));

            MenuCreator menuNacionalidades = new MenuCreator((IMenu) MenuController.Clone(), new MenuNacionalidades(bbdd, menuController), "Nacionalidades");
            menuNacionalidades.AddOptions(CreateCRUDMenu("nacionalidad"));

            MenuCreator menuAutores = new MenuCreator((IMenu) MenuController.Clone(), new MenuAutores(bbdd, menuController), "Autores");
            menuAutores.AddOptions(CreateCRUDMenu("autor"));

            MenuCreator menuComics = new MenuCreator((IMenu) MenuController.Clone(), new MenuComics(bbdd, menuController), "Comics");
            menuComics.AddOptions(CreateCRUDMenu("comic"));

            MenuCreator menuRelacion = new MenuCreator((IMenu) MenuController.Clone(), new MenuRelacion(bbdd, menuController), "Asignaciones");
            menuRelacion.AddOptions(CreateCRUDMenu("asignacion"));

            MenuCreator menuPais = new MenuCreator((IMenu) MenuController.Clone(), new MenuPaises(bbdd, menuController), "Paises");
            menuPais.AddOptions(CreateCRUDMenu("país"));

            MenuCreator menuEditorial = new MenuCreator((IMenu) MenuController.Clone(), new MenuEditoriales(bbdd, menuController), "Editoriales");
            menuEditorial.AddOptions(CreateCRUDMenu("editorial"));

            MenuCreator menuOtros = new MenuCreator((IMenu) MenuController.Clone(), new MenuOtros(), "Otros");
            menuOtros.AddMenu(menuRoles);
            menuOtros.AddMenu(menuNacionalidades);
            menuOtros.AddMenu(menuAutores);
            menuOtros.AddMenu(menuComics);
            menuOtros.AddMenu(menuRelacion);
            menuOtros.AddMenu(menuPais);
            menuOtros.AddMenu(menuEditorial);
            menuOtros.AddOption("Salir");

            MenuCreator menuEstadisticas = new MenuCreator((IMenu) MenuController.Clone(), new MenuEstadisticas(bbdd, menuController), "Estadísticas");
            menuEstadisticas.AddOptions("Número de comics por categoría", "Número de comics por autor", "Top 5 comics con mayor número de páginas", "Número de autores por nacionalidad", "Salir");

            menu.AddOptions(CreateCRUDMenu("categoria") [..^1]);

            menu.AddMenu(menuOtros);
            menu.AddMenu(menuEstadisticas);

            menu.AddOption("Salir");

            do menu.Execute(); while (menu.MenuOn);

        } 
        private string [] CreateCRUDMenu (string section) {

                string [] opts = new string [5];

                opts [0] = "Añadir " + section;
                opts [1] = "Ver " + section;
                opts [2] = "Modificar " + section;
                opts [3] = "Borrar " + section;
                opts [4] = "Salir";

                return opts;
            }
    }
}
