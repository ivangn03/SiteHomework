using AutoMapper;
using BLL.DTO;
using DAL.Context.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GoodService : GenericService<GoodDTO,Good>
    {
        public GoodService(IRepository<Good> repository) : base(repository)
        {
        }
    }
}
