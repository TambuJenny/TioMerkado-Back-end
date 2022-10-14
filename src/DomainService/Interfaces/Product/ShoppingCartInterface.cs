using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;

namespace DomainService.Interface.Product
{
    public interface ShoppingCartInterface
    {
        Task Create(ShoppingCartRequest body);
        Task<IList<ShoppingCartResponse>> GetAllUnsold();
        Task<IList<ShoppingCartResponse>> GetAllSold();
        Task Update(ShoppingCartRequest body);
        Task Delete(Guid id, Guid userId);
        Task<ShoppingCartResponse> GetById(Guid id);
    }
}
