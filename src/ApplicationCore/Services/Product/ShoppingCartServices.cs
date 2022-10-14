using AutoMapper;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface.Product;
using Infrastruture.Context;

namespace ApplicationCore.Services
{
    public class ShoppingCartServices : ShoppingCartInterface
    {
        private readonly DataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public ShoppingCartServices(DataBaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task Create(ShoppingCartRequest body)
        {
            
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingCartResponse>> GetAllSold()
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingCartResponse>> GetAllUnsold()
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCartResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ShoppingCartRequest body)
        {
            throw new NotImplementedException();
        }
    }
}
