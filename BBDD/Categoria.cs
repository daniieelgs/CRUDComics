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
    [Index(nameof(Nombre),IsUnique = true)]
    public class Categoria : ITable{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        public IList<Comic> Comics { get; set; }

        public Categoria() { }

        public Categoria (string nombre, string descripcion) {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public override string ToString () => Nombre;
    }
}
