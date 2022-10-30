using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel.DTO.Category
{
    public class CategoryCreateDto
    {
        public string? Active { get; set; }
        public string? Title { get; set; }
        public string? ParentID { get; set; }
        public string? Href { get; set; }
    }
}
