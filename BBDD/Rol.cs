using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace BBDD {
    [Index(nameof(Nombre), IsUnique = true)]
    public class Rol : ITable{

        public int Id { get; set; }
        public string Nombre { get; set; }

        public IList<Autor_Comic> Autores { get; set; } 

        public Rol () { }

        public Rol (string nombre) {
            Nombre = nombre;
        }

        public override string ToString () => Nombre;
    }
}
