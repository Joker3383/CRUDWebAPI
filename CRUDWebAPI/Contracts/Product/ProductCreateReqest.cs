namespace CRUDWebAPI.Contracts.Product
{
    public class ProductCreateReqest
    {
        public required string Name { get; set; }
        public required string Category { get; set; }
        public int Count { get; set; }
    }
}
