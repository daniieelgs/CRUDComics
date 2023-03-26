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
    public class Autor : ITable{

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int AgnoNacimiento { get; set; }
        
        public Nacionalidad Nacionalidad { get; set; }
        public int NacionalidadId { get; set; }
        public IList<Autor_Comic> Autores_Comics { get; set; }
        public Autor () { }

        public Autor(string nombre, int agnoNacimiento, int nacionalidadId) {
            initData(nombre, agnoNacimiento);
            NacionalidadId = nacionalidadId;
        }

        public Autor (string nombre, int agnoNacimiento, Nacionalidad nacionalidad) {
            initData(nombre, agnoNacimiento);
            Nacionalidad = nacionalidad;
        }
        private void initData (string nombre, int agnoNacimiento) {
            Nombre = nombre;
            AgnoNacimiento = agnoNacimiento;
        }

        public override string ToString () => Nombre;
    }
}
