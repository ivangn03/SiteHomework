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
        public ActionResult ManufacturerView()
        {
            ViewBag.Manufacturers = service.GetAll();
            return View();
        }
    }
}