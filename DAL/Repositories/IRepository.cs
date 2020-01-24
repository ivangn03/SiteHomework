using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T> where T: class
    {
        void AddOrUpdate(T data);
        T Delete(T data);
        IEnumerable<T> GetAll();
        T Get(int id);
        void SaveAll();
    }
}
