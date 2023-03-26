using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDD;
#pragma warning disable CS8618

namespace ColeccionComics {
    public class ModelContext : DbContext{

        private string DbName;
        private string ServerName;

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Autor_Comic> Autor_Comic { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Nacionalidad> Nacionalidades { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public ModelContext (string dbName = "comics", string serverName = "LAPTOP-NR927C3J") {
            DbName = dbName;
            ServerName = serverName;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@$"Server={ServerName};Database={DbName};Trusted_Connection=True;");

    }
}
