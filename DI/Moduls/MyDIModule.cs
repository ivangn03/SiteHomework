using BLL.DTO;
using BLL.Services;
using DAL.Context;
using DAL.Context.Models;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Moduls
{
    public class MyDIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ShopAdo>();
            Bind<IRepository<Category>>().To<CategoriesRepository>();
            Bind<IRepository<Good>>().To<GoodRepository>();
            Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
            Bind<IService<CategoryDTO>>().To<CategoryService>();
            Bind<IService<GoodDTO>>().To<GoodService>();
            Bind<IService<ManufacturerDTO>>().To<ManufacturerService>();
        }
    }
}
