using API.Data;

namespace API.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public DateTime CreateAt { get; set; }
        public int Quantity { get; set; }
        public int UpdateAt { get; set; }
        public double Price { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Size Size { get; set; } = null!;
        public virtual User User { get; set; } = null!;


    }
}

