using AutoMapper;
using BLL.DTO;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GoodService : IService<GoodDTO>
    {
        IRepository<Good> repository;
        IMapper mapper;
        public GoodService(IRepository<Good> repository)
        {
            this.repository = repository;
            MapperConfiguration config;
            config = new MapperConfiguration(cfg =>{
                    cfg.CreateMap<Good, GoodDTO>();
                    cfg.CreateMap<GoodDTO, Good>(); }
                );
            mapper = config.CreateMapper();
        }

        public void Create(GoodDTO data)
        {
            repository.AddOrUpdate(mapper.Map<Good>(data));
        }

        public GoodDTO Delete(GoodDTO data)
        {
            repository.Delete(repository.Get(data.GoodId));

            return data;
        }

        public GoodDTO Get(int id)
        {
            return mapper.Map<GoodDTO>(repository.Get(id));
        }

        public IEnumerable<GoodDTO> GetAll()
        {
            return repository.GetAll().Select(x => mapper.Map<GoodDTO>(x));
        }

        public void SaveAll()
        {
            repository.SaveAll();
        }
    }
}
