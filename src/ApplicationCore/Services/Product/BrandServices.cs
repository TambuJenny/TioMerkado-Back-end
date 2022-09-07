using AutoMapper;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface.Product;
using Infrastruture.Context;

namespace ApplicationCore.Services.Product
{
    public class BrandServices : BrandInterface
    {
        private DataBaseContext _dbContext;

        private readonly IMapper _mapper;

        public BrandServices(DataBaseContext dbContext,IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public Task Create(BrandRequest body)
        {
            throw new NotImplementedException();
        }

        public List<BrandResponse> GetAll()
        {
            /*var getAllBrands =  _dbContext.Brands.ToList();

            return _mapper.Map<List<BrandResponse>>(getAllBrands);*/
            throw new NotImplementedException();
           
        }

        public Task<BrandResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
