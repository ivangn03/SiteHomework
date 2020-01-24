using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T:class
    {
        DbContext dbContext;
        IDbSet<T> dbSet;
        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public void AddOrUpdate(T data)
        {
            dbSet.AddOrUpdate(data);
        }

        public T Delete(T data)
        {
            dbSet.Remove(data);
            return data;
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public void SaveAll()
        {
            dbContext.SaveChangesAsync();
        }

        ~GenericRepository()
        {
            dbContext.Dispose();
        }

    }
}
