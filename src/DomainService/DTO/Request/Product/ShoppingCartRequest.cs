using DomainService.Models;
using DomainService.Models.Enum;
using DomainService.Models.Product;

namespace DomaineService.Models.Request.Product
{
    public class ShoppingCartRequest
    {
        public PCModel Product { get; set; }
        public SaleStatus Status { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }

    }
}