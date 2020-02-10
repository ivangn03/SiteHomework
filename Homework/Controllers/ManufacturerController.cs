using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public class ManufacturerController : Controller
    {
        IService<ManufacturerDTO> service;
        public ManufacturerController(IService<ManufacturerDTO> service)
        {
            this.service = service;
        }
        // GET: Manufacturer
        public ActionResult ManufacturerView()
        {
            ViewBag.PageCount = (int)Math.Ceiling(service.GetAll().Count() / 6.0);
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            service.Delete(service.Get(id));
            return RedirectToAction("ManufacturerView");
        }
        public PartialViewResult ManufacturerTable(int id = 1)
        {
            var manufacturers= service.GetAll().OrderBy(x => x.ManufacturerId).Skip((id - 1) * 6).Take(6).ToList();
            return PartialView(manufacturers);
        }
    }
}