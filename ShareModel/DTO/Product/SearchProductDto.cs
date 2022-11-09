using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel.DTO.Product
{
    public class SearchProductDto : InputPageList
    {
        public string? Category { get; set; }
        public string? Search { get; set; }
    }
}
