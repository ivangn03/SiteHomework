using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Context;
using DAL.Repositories;

namespace BLL.Services
{
    public class CategoryService : GenericService<CategoryDTO, Category>
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {
        }
    }
}
