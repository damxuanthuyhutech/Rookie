using System.Reflection.Metadata.Ecma335;

namespace API.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Active { get; set; } 
        public string? Title { get; set; }
        public string?  ParentID { get; set; }
        public string? Href { get; set; }

        //public List<ProductCategory> ProductCategories { get; set; } = null!;


    }
}
