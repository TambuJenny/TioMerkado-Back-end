using AutoMapper;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface.Product;
using Infrastruture.Context;


namespace ApplicationCore.Services
{
    public class PcServices : PCInterface
    {
        private readonly DataBaseContext _dbContext;

        private readonly Mapper _mapper;

        public PcServices(DataBaseContext dbContext, Mapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task Create(PCRequest body)
        {
            
            throw new NotImplementedException();
        }

        public Task<List<PcResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PcResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
