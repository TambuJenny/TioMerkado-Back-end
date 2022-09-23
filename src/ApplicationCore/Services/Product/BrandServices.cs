using AutoMapper;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface.Product;
using DomainService.Models.Product;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services.Product
{
    public class BrandServices : BrandInterface
    {
        private DataBaseContext _dbContext;

        private readonly IMapper _mapper;

        public BrandServices(DataBaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Create(BrandRequest body)
        {
            var existeBrand = await _dbContext.Brands.Where(x => x.BrandName == body.BrandName).FirstOrDefaultAsync();

            if(existeBrand == null)
                throw new NotImplementedException("A marca já existe");

            existeBrand = new BrandModel{
                    BrandName = body.BrandName,
            };
            
            await _dbContext.Brands.AddAsync(existeBrand);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task<IList<BrandResponse>> GetAll()
        {
            var getAllBrands =  await _dbContext.Brands.ToListAsync();

            return _mapper.Map<List<BrandResponse>>(getAllBrands);
        }

        public async Task<BrandResponse> GetById(Guid id)
        {
           var existeBrand = await _dbContext.Brands.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(existeBrand == null)
                throw new NotImplementedException("A marca já existe");

            return _mapper.Map<BrandResponse>(existeBrand);
        }
    }
}
