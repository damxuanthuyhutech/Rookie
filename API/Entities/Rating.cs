using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public class Rating
{
    public int Id { get; set; }
    [Required]
    public int Star { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    [DataType(DataType.Date)]
    public DateTime UpdatedDate { get; set; }
    public Product Product { get; set; } = new Product();
    public User User { get; set; } = new User();
}