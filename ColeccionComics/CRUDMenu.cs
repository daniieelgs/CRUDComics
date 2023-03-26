using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    public abstract class CRUDMenu : IActionMenu {

        protected ComicsBBDDController bbdd;
        protected IMenu MenuController;

        public CRUDMenu (ComicsBBDDController bbdd, IMenu MenuController) {
            this.bbdd = bbdd;
            this.MenuController = MenuController;
        }

        public bool Select (int opt, string? msg) {

            switch (opt) {

                case 0: Add(); return true;
                case 1: See(); return true;
                case 2: Modify(); return true;
                case 3: Delete(); return true;
                default: return Other(opt, msg);

            }
        
        }

        public abstract void Add ();
        public abstract void Modify ();
        public abstract void Delete ();
        public abstract void See ();
        public abstract bool Other (int opt, string? msg);

        protected T? FindRegister<T, E> (IControlTable<T> control, string column, string type = "") where T : class {

            T? r = default(T);

            string? id = "";

            do {

                T [] MatchBy = null!;

                id = MenuController.PedirDatos("Id " + type);

                if (id == null) return null;

                if (id.IsDigit()) r = control.Get(int.Parse(id));
                    
                if (r == null) {
                    MatchBy = FindRegisterBy<T, E>(control, column, id);
                    if (MatchBy.Length == 0) MenuController.Error("Datos Erroneos");
                }

                if (r == null && MatchBy.Length == 1) r = MatchBy [0];
                else if (r == null && MatchBy.Length > 1) {
                    MenuController.Info("Varios resultados identificados con '" + id + "':");

                    MenuController.MostrarDatos<T>(MatchBy);

                }

            } while (r == null);

            return r;

        }

        protected T [] FindRegisterBy<T, E> (IControlTable<T> control, string column, string id) where T : class {
            E value = (E) Convert.ChangeType(id, typeof(E));
            return GetBy<T, E>(column, value, control);
        }

       protected T [] GetBy<T, E> (string column, E value, IControlTable<T> control) where T : class =>
            control
            .Include()
            .Where(x => x?
               .GetType()
               .GetProperty(column)?
               .GetValue(x, null) is E valor && valor.Equals(value)
            )
            .ToArray();

        protected T? FindRegister<T> (IControlTable<T> control, string type = "") where T : class {

            T? r = default(T);

            do {

                try {
                    string? id = MenuController.PedirDatos("Id " + type);

                    if (id == null) return null;

                    r = control.Get(int.Parse(id));

                } catch (Exception) { MenuController.Error("Datos Erroneos"); }


            } while (r == null);

            return r;

        }

    }
}
