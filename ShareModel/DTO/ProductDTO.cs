using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Desciption { get; set; }
        public double Discount { get; set; }
        public int NumberSold { get; set; }
        public double Price { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Detail { get; set; }

    }
}
