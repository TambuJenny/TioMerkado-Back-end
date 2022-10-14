using DomainService.Models.Enum;


namespace DomaineService.Models.Request.Product
{
    public class ShoppingCartRequest
    {
        public Guid ProductId { get; set; }
        public SaleStatus Status { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }

    }
}