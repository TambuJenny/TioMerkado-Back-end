using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace DomainService.Interface.Product
{
    public interface PCInterface
    {
        Task Create(PCRequest body);
        Task<List<PcResponse>> GetAll();
        Task<PcResponse> GetById(Guid id);
    }
}
