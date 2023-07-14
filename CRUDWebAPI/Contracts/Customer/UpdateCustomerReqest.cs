namespace CRUDWebAPI.Contracts.Customer
{
    public class UpdateCustomerReqest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
