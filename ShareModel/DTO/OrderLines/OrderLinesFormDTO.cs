

namespace ShareModel.DTO.OrderLines
{
    public class OrderLinesFormDTO /*: OrderLinesCreateDTO*/
    { 
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
