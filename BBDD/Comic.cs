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
    public class Comic : ITable{

        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroPaginas { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
        public IList<Autor_Comic> Autores_Comics { get; set; }

        public int? EditorialId { get; set; }
        public Editorial? Editorial { get; set; }
        public Comic () { }

        public Comic(string titulo, string descripcion, DateTime fecha, int numeroPaginas, int categoriaId, int editorialId) {
            initData(titulo, descripcion, fecha, numeroPaginas);
            CategoriaId = categoriaId;
            EditorialId = editorialId;
        }

        public Comic (string titulo, string descripcion, DateTime fecha, int numeroPaginas, Categoria categoria, Editorial editorial) {
            initData(titulo, descripcion, fecha, numeroPaginas);
            Categoria = categoria;
            Editorial = editorial;
        }

        private void initData (string titulo, string descripcion, DateTime fecha, int numeroPaginas) {
            Titulo = titulo;
            Descripcion = descripcion;
            Fecha = fecha;
            NumeroPaginas = numeroPaginas;
        }

        public override string ToString () => Titulo;
    }
}
