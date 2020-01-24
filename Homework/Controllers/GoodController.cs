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
        public ActionResult GoodView()
        {
            ViewBag.Goods = service.GetAll();
            return View();
        }
    }
}