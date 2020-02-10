﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GoodDTO
    {
        public int GoodId { get; set; }  
        public string GoodName { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
    }
}
