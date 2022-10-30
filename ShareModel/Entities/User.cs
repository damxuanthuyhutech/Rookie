using ShareModel.Entities;
using ShareModel.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareModel.Entities
{
    public class User
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Active { get; set; }
        public string? AvatarImage { get; set; }
        public string? Email { get; set; }
        public string? Firt_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Phone { get; set; }
        public string? PasswordHash { get; set; }
        public string? Profile { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string? UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public string? Address { get; set; }


        public List<Order> Order { get; set; } = null!;
        public List<Rating> Ratings { get; set; } = null!;
        public List<CartItem> CartItem { get; set; } = null!;


    }
}
