using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public DateTime CreateAt { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Content { get; set; }
        public double Price { get; set; }

        
        public virtual Product Product { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual Size Size { get; set; } = null!;

        public List<Rating> Ratings { get; set; } = null!;




    }
}
