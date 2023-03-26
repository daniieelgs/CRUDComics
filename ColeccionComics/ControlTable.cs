using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionComics {
    public abstract class ControlTable<T> : IControlTable<T> where T : class, BBDD.ITable {

        protected DbContext context;
        protected DbSet<T> DB;
        private string []? uniqueIndex;

        public ControlTable (DbContext context, DbSet<T> bbdd) {
            this.context = context;
            this.DB = bbdd;
            uniqueIndex = null;
        }

        public ControlTable(DbContext context, DbSet<T> bbdd, params string [] uniques) : this(context, bbdd) => uniqueIndex = uniques;

        protected virtual bool CheckUnique(T item) {

            if (uniqueIndex is null) return true;

            T? same = null;

            foreach(string index in uniqueIndex){

                Object? valueItem = ValueProperty<T>(index, item);
                same = DB.ToList().FirstOrDefault(x => ValueProperty<T>(index, x)!.Equals(valueItem));

            }

            return same == null;

        }

        private Object? ValueProperty<E> (string propertyName, Object obj) => typeof(E).GetProperty(propertyName)!.GetValue(obj, null);

        public virtual T Add (T item) {

            if (!CheckUnique(item)) throw new Exception("Violation on unique index");

            context.Add(item);

            context.SaveChanges();

            return item;
        }
        public virtual T Get (int id) => DB.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException($"Register with id '{id}' not found");
        public virtual T [] GetAll () => DB.ToArray();
        public abstract T [] Include ();
        public virtual T Modify (T item, T newItem) {
            
            if (!CheckUnique(newItem)) throw new Exception("Violation on unique index");

            //T x = Get(item.Id);

            typeof(T).GetProperties()
                .Where(x => x.Name != "Id" && !typeof(IEnumerable<Object>).IsAssignableFrom(x.PropertyType) && !context.Model.GetEntityTypes().Select(t => t.ClrType).ToList().Contains(x.PropertyType) )
                .ToList()
                .ForEach(p => p.SetValue(item, ValueProperty<T>(p.Name, newItem)));

            context.SaveChanges();

            return item;
        }
        public virtual T Modify (int id, T newItem) => Modify(Get(id), newItem);
        public virtual T Remove (int id) => Remove(Get(id));
        public virtual T Remove (T item) {
            DB.Remove(item);

            context.SaveChanges();

            Console.WriteLine("eliminado");

            return item;
        }
        public DbSet<T> GetDbSet () => DB;

    }
}
