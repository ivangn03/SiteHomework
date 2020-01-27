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
    public class CategoryController : Controller
    {
        IService<CategoryDTO> service = new CategoryService(new CategoriesRepository(new ShopAdo()));
        // GET: Category
        public ActionResult CategoryView(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(service.GetAll().Count() / 4.0);
            ViewBag.Categories = service.GetAll().OrderBy(x=>x.CategoryId).Skip((id-1)*4).Take(4).ToList();
            return View();
        }
    }
}