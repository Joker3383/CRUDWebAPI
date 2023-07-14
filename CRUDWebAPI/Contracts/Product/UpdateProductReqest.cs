namespace CRUDWebAPI.Contracts.Product
{
    public class UpdateProductReqest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public int Count { get; set; }
    }
}
