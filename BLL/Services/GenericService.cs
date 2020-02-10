using AutoMapper;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenericService<DTO,M> : IService<DTO> where DTO : class where M:class
    {
        IRepository<M> repository;
        protected IMapper mapper;
        public GenericService(IRepository<M> repository)
        {
            this.repository = repository;
            MapperConfiguration config;
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<M, DTO>();
                cfg.CreateMap<DTO, M>();
            }
            );
            mapper = config.CreateMapper();
        }

        public void CreateOrUpdate(DTO data)
        {
            repository.AddOrUpdate(mapper.Map<M>(data));
        }

        public DTO Delete(DTO data)
        {
            repository.Delete(repository.Get(Convert.ToInt32( data.GetType().GetProperty(data.ToString().Substring(8, data.ToString().Length - 11) + "Id").GetValue(data))));//Викликає Id поле із DTO.
            return data; 
        }

        public DTO Get(int id)
        {
            return mapper.Map<DTO>(repository.Get(id));
        }

        public IQueryable<DTO> GetAll()
        {
            //.Select(x => mapper.Map<DTO>(x));
            return mapper.ProjectTo<DTO>(repository.GetAll());
        }

        public void SaveAll()
        {
            repository.SaveAll();
        }
    }
}
