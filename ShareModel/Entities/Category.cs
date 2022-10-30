using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace ShareModel.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Active { get; set; } 
        public string? Title { get; set; }
        public string?  ParentID { get; set; }
        public string? Href { get; set; }

        //[ForeignKey("ProductId")]
        //public List<Product> Products { get; set; } = null!;
        public ICollection<Product>? Products { get; set; } //1


    }
}
