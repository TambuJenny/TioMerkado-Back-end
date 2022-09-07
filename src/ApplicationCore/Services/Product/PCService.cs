using AutoMapper;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface.Product;
using DomainService.Models.Product;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;
using Models.Enum;

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

        public async Task Create(PCRequest body)
        {
            if (body == null)
                throw new NotImplementedException("Objeto vazio");

            await _dbContext.Pcs.AddRangeAsync(_mapper.Map<PCModel>(body));
            await _dbContext.SaveChangesAsync();
        }

        public List<PcResponse> GetAllAvailable()
        {
            var getAllPc = _dbContext.Pcs.ToList().Where(x => x.Status == StatusProduct.available);

            return _mapper.Map<List<PcResponse>>(getAllPc);
        }

        public List<PcResponse> GetAll()
        {
            var getAllPc = _dbContext.Pcs.ToList();

            return _mapper.Map<List<PcResponse>>(getAllPc);
        }

        public async Task<PcResponse> GetById(Guid id)
        {
            var existeIdPc = await (
                from p in _dbContext.Pcs
                where p.Id == id && p.Status != StatusProduct.sold
                select p
            ).SingleOrDefaultAsync();

            if (existeIdPc == null)
                throw new NotImplementedException("Computador vendido");

            return _mapper.Map<PcResponse>(existeIdPc);
        }
    }
}
