using API.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public double Discount { get; set; }
        public int Status { get; set; }
        public double Tax { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int NumberItem { get; set; }
        public double Total { get; set; }

        public virtual User User { get; set; } = null!;

        public List<OrderItem> OrderItems { get; set; } = null!;
        
   
        
        
        
        
        
    }
}
