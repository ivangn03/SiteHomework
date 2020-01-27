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
            ViewBag.PageCount = (int)Math.Ceiling(service.GetAll().Count() / 4.0);
            ViewBag.Goods = service.GetAll().OrderBy(x => x.GoodId).Skip((id - 1) * 4).Take(4).ToList();
            return View();
        }
    }
}