namespace API.Entities;

public class Order
{
    public int Id { get; set; }
    public User User { get; set; } = new User();
    public virtual ICollection<OrderLine>? OrderLines { get; set; } = new List<OrderLine>();
}