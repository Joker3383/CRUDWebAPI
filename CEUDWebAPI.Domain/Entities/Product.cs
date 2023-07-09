namespace CEUDWebAPI.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public int Count { get; set; }
    }
}
