using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareModel.Entities
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

