using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GoodDTO
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string ManufactureName { get; set; }
    }
}
