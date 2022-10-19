namespace API.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public string? SizeName { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<CartItem> CartItem { get; set; } = null!;



    }
}
