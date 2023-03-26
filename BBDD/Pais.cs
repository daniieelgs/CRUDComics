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
    public class Pais : ITable{

        public int Id { get; set; }

        public string Nombre { get; set; }

        public IList<Nacionalidad> Nacionalidades { get; set; }
        
        public IList<Editorial> Editoriales { get; set; }
        public Pais () { }

        public Pais (string nombre) => Nombre = nombre;

        public override string ToString () => Nombre;
    }
}
