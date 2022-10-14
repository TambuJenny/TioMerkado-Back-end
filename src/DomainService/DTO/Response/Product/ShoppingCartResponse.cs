using DomainService.Models;
using DomainService.Models.Enum;
using DomainService.Models.Product;

namespace DomaineService.Models.Response.Product
{
    public class ShoppingCartResponse
    {
        public Guid Id { get; set; }
        public PCModel Product { get; set; }
        public SaleStatus Status { get; set; }
        public int Quantity { get; set; }
        public UserModel UserId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
