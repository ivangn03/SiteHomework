using BLL.DTO;
using BLL.Services;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public class ManufacturerController : Controller
    {
        IService<ManufacturerDTO> service = new ManufacturerService(new ManufacturerRepository(new ShopAdo()));
        // GET: Manufacturer
        public ActionResult ManufacturerView(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(service.GetAll().Count() / 4.0);
            ViewBag.Manufacturers = service.GetAll().OrderBy(x => x.ManufacturerId).Skip((id - 1) * 4).Take(4).ToList();
            return View();
        }
    }
}