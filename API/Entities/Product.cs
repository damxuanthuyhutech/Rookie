using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string Author { get; set; } /*= string.Empty;*/
    //[Column(TypeName = "decimal(18, 2)")]
    public double Price { get; set; }
    public int Quantity { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime UpdatedDate { get; set; }
    public Category? Category { get; set; }
    public ICollection<OrderLine>? OrderLines { get; set; }
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}