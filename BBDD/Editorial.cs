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
    public class Editorial : ITable{

        public int Id { get; set; }
        public string Nombre { get; set; }

        public int PaisId { get; set; }
        public Pais Pais { get; set; }

        public IList<Comic> Comics { get; set; }
        public Editorial () { }

        public Editorial(string nombre, int paisId) {
            Nombre = nombre;
            PaisId = paisId;
        }

        public Editorial (string nombre, Pais pais) {
            Nombre = nombre;
            Pais = pais;
        }

        public override string ToString () => Nombre;

    }
}
