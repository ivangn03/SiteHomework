using BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Models
{
    public class GoodViewModel
    {                   
        public GoodDTO Good { get; set; }
        public string SelectedCategoryName { get; set; }
        [Display(Name = "Category")]
        public IEnumerable<SelectListItem> Category { get; set; }
        [Display(Name = "Manufacturer")]
        public IEnumerable<SelectListItem> Manufacturer { get; set; }
    }
}