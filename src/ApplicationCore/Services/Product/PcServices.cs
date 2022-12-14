using AutoMapper;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface.Product;
using DomainService.Models;
using DomainService.Models.Product;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;
using Models.Enum;

namespace ApplicationCore.Services
{
    public class PcServices : PCInterface
    {
        private readonly DataBaseContext _dbContext;

        private readonly IMapper _mapper;

        public PcServices(DataBaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Create(PCRequest body)
        {
            if (body == null)
                throw new NotImplementedException("Objeto vazio");

            var pcObject = new PCModel();

            pcObject.Failure = body.Failure;
            pcObject.Images = body.Images;
            pcObject.LastPrice = body.LastPrice;
            pcObject.FirtPrice = body.FirtPrice;
            pcObject.HardDisk = body.HardDisk;
            pcObject.Ram = body.Ram;
            pcObject.ProcessorSpeed = body.ProcessorSpeed;
            pcObject.ProductName = body.ProductName;
            pcObject.Status = StatusProduct.available;
            pcObject.Description = body.Description;

            pcObject.User = await (
                from u in _dbContext.Users
                where u.Id == body.UserId
                select u
            ).SingleOrDefaultAsync();

            if (pcObject.User == null)
                throw new NotImplementedException("Usuario selecionado não existe");

            pcObject.Brand = await (
                from u in _dbContext.Brands
                where u.Id == body.BrandId
                select u
            ).SingleOrDefaultAsync();

            if (pcObject.Brand == null)
                throw new NotImplementedException("Marca selecionada não existe");

            await _dbContext.Pcs.AddRangeAsync(pcObject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PcResponse>> GetAllAvailable()
        {
            var getAllPc = await _dbContext.Pcs
                .Include(x => x.User)
                .Include(x => x.Brand)
                .Where(x => x.Status == StatusProduct.available)
                .ToListAsync();

            var AllpcResponse = new List<PcResponse>();
            var pcResponse = new PcResponse();

            foreach (var item in getAllPc)
            {
                pcResponse.Id = item.Id;
                pcResponse.Brand = new BrandModel
                {
                    Id = item.Brand.Id,
                    BrandName = item.Brand.BrandName
                };
                pcResponse.ProductName = item.ProductName;
                pcResponse.Description = item.Description;
                pcResponse.ProcessorSpeed = item.ProcessorSpeed;
                pcResponse.HardDisk = item.HardDisk;
                pcResponse.FirtPrice = item.FirtPrice;
                pcResponse.LastPrice = item.LastPrice;
                pcResponse.Failure = item.Failure;
                pcResponse.Ram = item.Ram;
                pcResponse.Images = item.Images;
                pcResponse.User = new UserModel
                {
                    Id = item.User.Id,
                    FirstName = item.User.FirstName,
                    LastName = item.User.LastName
                };

                AllpcResponse.Add(pcResponse);
            }

            return AllpcResponse;
        }

        public async Task<List<PcResponse>> GetAll()
        {
            var getAllPc = await _dbContext.Pcs
                .Include(x => x.User)
                .Include(x => x.Brand)
                .ToListAsync();

            var AllpcResponse = new List<PcResponse>();
            var pcResponse = new PcResponse();

            foreach (var item in getAllPc)
            {
                AllpcResponse.Add(
                    new PcResponse
                    {
                        Brand = new BrandModel
                        {
                            Id = item.Brand.Id,
                            BrandName = item.Brand.BrandName
                        },
                        Id = item.Id,
                        ProductName = item.ProductName,
                        Description = item.Description,
                        ProcessorSpeed = item.ProcessorSpeed,
                        HardDisk = item.HardDisk,
                        FirtPrice = item.FirtPrice,
                        LastPrice = item.LastPrice,
                        Failure = item.Failure,
                        Ram = item.Ram,
                        Images = item.Images,
                        User = new UserModel
                        {
                            Id = item.User.Id,
                            FirstName = item.User.FirstName,
                            LastName = item.User.LastName
                        }
                    }
                );
            }

            return AllpcResponse;
        }

        public async Task<PcResponse> GetById(Guid id)
        {
            var existeIdPc = await _dbContext.Pcs
                .Include(x => x.User)
                .Include(x => x.Brand)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (existeIdPc == null)
                throw new NotImplementedException("Computador não existe");

            var pcResponse = new PcResponse
            {
                Id = existeIdPc.Id,
                Brand = new BrandModel
                {
                    Id = existeIdPc.Brand.Id,
                    BrandName = existeIdPc.Brand.BrandName,
                },
                ProductName = existeIdPc.ProductName,
                Description = existeIdPc.Description,
                ProcessorSpeed = existeIdPc.ProcessorSpeed,
                HardDisk = existeIdPc.HardDisk,
                FirtPrice = existeIdPc.FirtPrice,
                LastPrice = existeIdPc.LastPrice,
                Failure = existeIdPc.Failure,
                Ram = existeIdPc.Ram,
                Images = existeIdPc.Images,
                User = new UserModel
                {
                    Id = existeIdPc.User.Id,
                    FirstName = existeIdPc.User.FirstName,
                    LastName = existeIdPc.User.LastName,
                }
            };

            return pcResponse;
        }

        public async Task Update(PcResponse body)
        {
            var existePc = await (
                from u in _dbContext.Pcs
                where u.Id == body.Id
                select u
            ).SingleOrDefaultAsync();

            if (existePc == null)
                throw new NotImplementedException("Pc não existe");

            existePc.Failure = body.Failure;
            existePc.Images = body.Images;
            existePc.LastPrice = body.LastPrice;
            existePc.FirtPrice = body.FirtPrice;
            existePc.HardDisk = body.HardDisk;
            existePc.Ram = body.Ram;
            existePc.ProcessorSpeed = body.ProcessorSpeed;
            existePc.ProductName = body.ProductName;
            existePc.Status = StatusProduct.available;
            existePc.Description = body.Description;

            existePc.User = await (
                from u in _dbContext.Users
                where u.Id == body.User.Id
                select u
            ).SingleOrDefaultAsync();

            if (existePc.User == null)
                throw new NotImplementedException("Usuario selecionado não existe");

            existePc.Brand = await (
                from u in _dbContext.Brands
                where u.Id == body.Brand.Id
                select u
            ).SingleOrDefaultAsync();

            if (existePc.Brand == null)
                throw new NotImplementedException("Marca selecionada não existe");

            _dbContext.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            var getPc = await _dbContext.Pcs.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (getPc == null)
                throw new NotImplementedException("Computador não existe");

            _dbContext.Pcs.Remove(getPc);
            await _dbContext.SaveChangesAsync();
        }
    }
}
