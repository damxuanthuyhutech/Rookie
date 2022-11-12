

namespace ShareModel.DTO.OrderLines
{
    public class OrderLinesFormDTO /*: OrderLinesCreateDTO*/
    { 
        public int Quantity { get; set; }
        public int Order { get; set; }
        public int Product { get; set; }
    }
}
