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
        public ActionResult CategoryView()
        {
            ViewBag.Categories = service.GetAll();
            return View();
        }
    }
}