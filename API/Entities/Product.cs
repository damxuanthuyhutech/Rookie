namespace API.Entities
{
    public class Product
    {
            public int Id { get; set; }
            public double AverageRating { get; set; } //diem trung binh sao cua san pham
            public DateTime CreatedDate { get; set; }    
            public string? Desciption { get; set; }
            public double Discount { get; set; }
            public string? MetaTitle { get; set; }
            public int NumberRating { get; set; }
            public int NumberSold { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public string? Title { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string? Content { get; set; }
            public string? Detail { get; set; }
            public int Active { get; set; }

        //ForenKey
        public List<OrderItem> OrderItems { get; set; } = null!;
        public List<CartItem> CartItem { get; set; } = null!;
        public List<Image> Images { get; set; } = null!;
        //public List<ProductCategory> ProductCategories { get; set; } = null!;







    }
}
