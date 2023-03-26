using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    public class MenuOtros : IActionMenu {
        public bool Select (int opt, string? msg) => msg != "Salir";
    }
}
