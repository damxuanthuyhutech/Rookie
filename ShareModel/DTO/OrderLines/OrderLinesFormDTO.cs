using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel.DTO.OrderLines
{
    public class OrderLinesFormDTO : OrderLinesCreateDTO
    {
        public int Quantity { get; set; }
        public int Order { get; set; }
        public int Product { get; set; }

    }
}
