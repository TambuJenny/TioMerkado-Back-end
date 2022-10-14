using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;

namespace DomainService.Interface.Product
{
    public interface ShoppingCartInterface
    {
        Task Create(ShoppingCartRequest body);
        Task<List<ShoppingCartResponse>> GetAllUnsold();
        Task<List<ShoppingCartResponse>> GetAllSold();
        Task Update(ShoppingCartRequest body);
        Task Delete(Guid id);
        Task<ShoppingCartResponse> GetById(Guid id);
    }
}
