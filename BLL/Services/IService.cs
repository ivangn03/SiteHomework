using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IService <T> where T : class
    {
      void Create(T data);
      T Delete(T data);
      IEnumerable<T> GetAll();
      T Get(int id);
      void SaveAll();       
    }
}
