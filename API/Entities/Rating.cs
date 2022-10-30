using API.Data;
using ShareModel.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Rating
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreteDate { get; set; }      
        public RecomentStars Stars{ get; set; }

        public virtual OrderItem OrderItem { get; set; } = null!;
        public virtual User User { get; set; } = null!;


    }
}
