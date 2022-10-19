namespace API.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string? Link { get; set; }

        public virtual Product Product { get; set; } = null!;

        


    }
}
