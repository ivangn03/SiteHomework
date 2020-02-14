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
        public PartialViewResult ManufacturerEdit(int id = 1)
        {
            if (id < 0)
            {
                ManufacturerDTO createDTO = new ManufacturerDTO();
                service.CreateOrUpdate(createDTO);
                return PartialView(createDTO);
            }
            ManufacturerDTO manufacturer = service.Get(id);
            return PartialView(manufacturer);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            service.Delete(service.Get(id));
            return RedirectToAction("ManufacturerView");
        }
        [HttpPost]
        public ActionResult ManufacturerEdit(ManufacturerDTO manufacturer)
        {
            if (ModelState.IsValid)
            {
                service.CreateOrUpdate(manufacturer);
                service.SaveAll(); return RedirectToAction("ManufacturerView");
            }
            return RedirectToAction("ManufacturerEdit");
        }
        public PartialViewResult ManufacturerTable(int id = 1)
        {
            var manufacturers= service.GetAll().OrderBy(x => x.ManufacturerId).Skip((id - 1) * 6).Take(6).ToList();
            return PartialView(manufacturers);
        }
    }
}