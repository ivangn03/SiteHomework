using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Services;

namespace Homework.Controllers
{
    public class GoodController : Controller
    {
        IService<GoodDTO> service;
        // GET: Good
        public GoodController(IService<GoodDTO> service)
        {
            this.service = service;
        }
        public ActionResult GoodView()
        {
            ViewBag.PageCount = (int)Math.Ceiling(service.GetAll().Count() / 6.0);
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            service.Delete(service.Get(id));
            return RedirectToAction("GoodView");
        }
        public PartialViewResult GoodTable(int id = 1)
        {
            var goods = service.GetAll().OrderBy(x => x.GoodId).Skip((id - 1) * 6).Take(6).ToList();
            return PartialView(goods);
        }
        public PartialViewResult GoodEdit(int id = 1)
        {
            GoodDTO good = service.Get(id);
            return PartialView(good);
        }
        [HttpPost]
        public ActionResult GoodEdit(GoodDTO good)
        {
            if (ModelState.IsValid)
            {
                service.CreateOrUpdate(good);
                service.SaveAll();
            return RedirectToAction("GoodView");
            }
            return RedirectToAction("GoodEdit");
        }
    }
}