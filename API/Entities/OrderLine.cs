namespace API.Entities;

public class OrderLine
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public virtual Order Order { get; set; } = new Order();
    public virtual Product Product { get; set; } = new Product();
}