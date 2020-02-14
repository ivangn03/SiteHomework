using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public class CategoryController : Controller
    {
        IService<CategoryDTO> service;
        // GET: Category
        public CategoryController(IService<CategoryDTO> service)
        {
            this.service = service;
        }
        public ActionResult CategoryView()
        {
            ViewBag.PageCount = (int)Math.Ceiling(service.GetAll().Count() / 6.0);
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            service.Delete(service.Get(id));
            return RedirectToAction("CategoryView");
        }
        public PartialViewResult CategoryTable(int id = 1)
        {
            var categories = service.GetAll().OrderBy(x => x.CategoryId).Skip((id - 1) * 6).Take(6).ToList();
            return PartialView(categories);
        }
     
        public PartialViewResult CategoryEdit(int id = 1)
        {
            if (id < 0)
            {
                CategoryDTO createDTO = new CategoryDTO();
                service.CreateOrUpdate(createDTO);
                return PartialView(createDTO);
            }
            CategoryDTO category = service.Get(id);
            return PartialView(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                service.CreateOrUpdate(category);
                service.SaveAll(); return RedirectToAction("CategoryView");
            }
            return RedirectToAction("CategoryEdit");
        }
    }
}