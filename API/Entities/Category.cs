using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<Product>? Products { get; set; }

}