using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Services;
using DAL.Context;
using DAL.Repositories;

namespace Homework.Controllers
{
    public class GoodController : Controller
    {
        IService<GoodDTO> service = new GoodService(new GoodRepository(new ShopAdo()));
        // GET: Good
        public ActionResult GoodView(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(service.GetAll().Count() / 6.0);
            return View();
        }
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
    }
}