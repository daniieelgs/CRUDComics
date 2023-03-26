using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    public interface IMenu : ICloneable {

        public void EjecutarMenu (params string[] options);

        public delegate void Notify (int opt);

        public event Notify OnOptionSelect;

        public string[]? PedirDatos (params string[] msg);

        public string? PedirDatos (string msg);

        public void MostrarDatos (string [] titles, string [][] values);

        public void MostrarDatos<T> (string [] [] values);
        public void MostrarDatos<T> (T [] values);
        public bool Confirm (string msg = "Estas seguro de que quiere continuar?");
        public void Error (string msg = "Fatal Error");

        public void Info (string msg);
    }
}
