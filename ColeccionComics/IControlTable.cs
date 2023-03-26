using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    public interface IControlTable<T> where T : class{

        public T [] GetAll ();
        public T [] Include ();
        public T Remove (int id);
        public T Remove(T item);
        public T Add (T item);
        public T Get (int id);
        public T Modify (T item, T newItem);
        public T Modify (int id, T newItem);

        public DbSet<T> GetDbSet ();
    }
}
