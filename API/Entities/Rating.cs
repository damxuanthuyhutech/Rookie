using API.Data;
using ShareModel.Enum;

namespace API.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreteDate { get; set; }      
        public RecomentStars Stars{ get; set; }

        public virtual OrderItem OrderItem { get; set; } = null!;
        public virtual User User { get; set; } = null!;


    }
}
