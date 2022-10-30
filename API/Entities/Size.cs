using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Size
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? SizeName { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<CartItem> CartItem { get; set; } = null!;



    }
}
