using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel.DTO.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? Author { get; set; } = string.Empty;

        public decimal? AverageRating { get; set; }

        //[Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }

        public string? Category { get; set; }


    }

    public class TestQuery
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
