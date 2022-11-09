using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel.DTO
{
    public class InputPageList
    {
        public int? Page { get; set; } = 0;
        public int? MaxResponse { get; set; } = 10;
        public int? Skip { get; set; } = 0;
    }
}
