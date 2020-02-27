using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Services;
using Homework.Models;

namespace Homework.Controllers
{
    public class GoodController : Controller
    {
        IService<GoodDTO> service;
        IService<ManufacturerDTO> service2;
        IService<CategoryDTO> service3;
        GoodViewModel goodViewModel;
        // GET: Good
        public GoodController(IService<GoodDTO> service, IService<ManufacturerDTO> service2, IService<CategoryDTO> service3)
        {
            this.service = service;
            this.service2 = service2;
            this.service3 = service3;
        }
        public ActionResult GoodView()
        {
            ViewBag.PageCount = (int)Math.Ceiling(service.GetAll().Count() / 6.0);
            return View();
        }
        [Authorize]
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

        [Authorize]
        public PartialViewResult GoodEdit(int id = 1)
        {
            var manufacturers = service2.GetAll();
            var categories = service3.GetAll();
            if (id < 0)
            {
                GoodDTO createDTO = new GoodDTO();
                service.CreateOrUpdate(createDTO);
                goodViewModel = new GoodViewModel
                {
                    Good = createDTO,
                    Category = categories.ToList().Select(category => new SelectListItem
                    {
                        Value = category.CategoryId.ToString(),
                        Text = category.CategoryName
                    }),
                    Manufacturer = manufacturers.ToList().Select(manufacturer => new SelectListItem
                    {
                        Value = manufacturer.ManufacturerId.ToString(),
                        Text = manufacturer.ManufacturerName
                    }

                ),
                };
                return PartialView(goodViewModel);
            }
            GoodDTO good = service.Get(id);
            goodViewModel = new GoodViewModel
            {
                Good = good,
                Category = categories.ToList().Select(category => new SelectListItem
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.CategoryName
                }),
                Manufacturer = manufacturers.ToList().Select(manufacturer => new SelectListItem
                {
                    Value = manufacturer.ManufacturerId.ToString(),
                    Text = manufacturer.ManufacturerName
                }
               
                ),
            };
            return PartialView(goodViewModel);
        }
        [Authorize]
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