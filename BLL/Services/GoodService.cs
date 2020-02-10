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
            MapperConfiguration config;
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GoodDTO, Good>();
                cfg.CreateMap<Good, GoodDTO>().ForMember(fld => fld.CategoryName, ctg => ctg.MapFrom(des => des.Category.CategoryName))
                .ForMember(fld => fld.ManufacturerName, ctg => ctg.MapFrom(des => des.Manufacturer.ManufacturerName));
            }
            );
            mapper = config.CreateMapper();
        }
    }
}
