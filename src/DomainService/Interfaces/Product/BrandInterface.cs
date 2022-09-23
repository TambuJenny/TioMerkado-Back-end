using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;

namespace DomainService.Interface.Product
{
    public interface BrandInterface
    {
        Task Create(BrandRequest body);
        Task<IList<BrandResponse>> GetAll();
        Task <BrandResponse> GetById(Guid id);
    }
}
