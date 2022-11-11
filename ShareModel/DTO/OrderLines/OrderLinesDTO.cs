using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel.DTO.OrderLines
{
    public class OrderLinesDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Order { get; set; } 
        public string? Product { get; set; } 
        public double PriceProduct { get; set; }
    }
}
