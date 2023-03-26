using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    public class MenuCreator {

        public string Nombre { get; set; }

        private IMenu MenuController;
        private IActionMenu ActionMenu;

        private List<String> options;
        private Dictionary<int, MenuCreator> menus;

        public bool MenuOn { get; set; }

        public MenuCreator(IMenu menuController, IActionMenu menuAction, string nombre) {
            Nombre = nombre;
            MenuController = menuController;
            ActionMenu = menuAction;
            options = new List<string>();
            menus = new Dictionary<int, MenuCreator>();

            menuController.OnOptionSelect += opt => {

                if (!MenuOn) return;

                if (menus.ContainsKey(opt)) {
                    MenuOn = false;
                    menus [opt].Execute();
                    MenuOn = true;
                } else {
                    MenuOn = ActionMenu.Select(opt, options [opt]);
                }

            };
        }

        public void AddOption (string option) => options.Add(option);
        public void AddOptions (params string [] option) => option.ToList().ForEach(AddOption);

        public void AddMenu (MenuCreator menu) {
            options.Add(menu.Nombre);
            menus.Add(options.Count() - 1, menu);
        }

        public void AddMenus (params MenuCreator [] menus) => menus.ToList().ForEach(AddMenu);

        public void Execute () {

            MenuOn = true;

            MenuCreator? menu = menus.Select(x => x.Value).FirstOrDefault(x => x.MenuOn);

            if (menu != null) {
                MenuOn = false;
                menu.Execute();
                MenuOn = true;
            } else {
                MenuController.EjecutarMenu(options.ToArray());
            }
        }
    }
}
