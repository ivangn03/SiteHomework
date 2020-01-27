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
    public class ManufacturerService : GenericService<ManufacturerDTO, Manufacturer>
    {
        public ManufacturerService(IRepository<Manufacturer> repository) : base(repository)
        {
        }
    }
}
