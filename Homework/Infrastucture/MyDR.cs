using DI.Moduls;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Infrastucture
{
    public class MyDR : IDependencyResolver
    {
        IKernel kernel;
        public MyDR()
        {
            kernel = new StandardKernel(new MyDIModule());
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}