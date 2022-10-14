using DomainService.Models;
using DomainService.Models.Enum;
using DomainService.Models.Product;

namespace Models.Product
{
    public class ShoppingCartModel
    {
        public Guid Id { get; set; } = new Guid();
        public PCModel ProductId { get; set; }
        public SaleStatus Status { get; set; }
        public int Quantity { get; set; }
        public UserModel? UserId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
