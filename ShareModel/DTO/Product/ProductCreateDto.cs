using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel.DTO.Product
{
    public class ProductCreateDto
    {
        
        //public double AverageRating { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string? Desciption { get; set; }
        //public double Discount { get; set; }
        //public string? MetaTitle { get; set; }
        //public int NumberRating { get; set; }
        //public int NumberSold { get; set; }
        //public double Price { get; set; }
        //public int Quantity { get; set; }
        //public string? Title { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string? Content { get; set; }
        //public string? Detail { get; set; }
        //public int Active { get; set; }

  
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string Author { get; set; } = string.Empty;
        //[Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
        
    }
}
