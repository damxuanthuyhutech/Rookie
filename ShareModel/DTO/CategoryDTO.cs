using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel.DTO
{
    public class CategoryDTO
    {

        public int Id { get; set; }       
        public string? Title { get; set; }
        public string? Href { get; set; }

     


    }
}
