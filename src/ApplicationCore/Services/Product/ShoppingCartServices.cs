using System.Data.Entity;
using AutoMapper;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface.Product;
using DomainService.Models.Enum;
using Infrastruture.Context;
using Models.Enum;
using Models.Product;

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

        public async Task Create(ShoppingCartRequest body)
        {
            Guid userId = body.UserId;

            var existeProductInCart = await _dbContext.ShoppingCart
                .Where(
                    x =>
                        x.Id == body.ProductId
                        && x.UserId.Id == body.UserId
                        && x.Status != SaleStatus.Sold
                )
                .FirstOrDefaultAsync();

            var existeUser = _dbContext.Users
                .Where(x => x.Id == body.UserId && x.Role == Roles.User_Simple)
                .Any();

            if (!existeUser)
                throw new NotImplementedException("Usuário não existe tentativa de fraude");

            if (userId == null)
            {
                await _dbContext.ShoppingCart.AddAsync(
                    new ShoppingCartModel
                    {
                        ProductId = existeProductInCart.ProductId,
                        Quantity = body.Quantity,
                        Status = SaleStatus.Cart,
                    }
                );
                await _dbContext.SaveChangesAsync();
            }
            else if (existeUser)
            {
                if (existeProductInCart != null)
                    throw new NotImplementedException("Produto Já se encontra no carrinho");

                await _dbContext.ShoppingCart.AddAsync(_mapper.Map<ShoppingCartModel>(body));
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id, Guid userId)
        {
            var existeProductInCart = await _dbContext.ShoppingCart
                .Where(x => x.Id == id && x.UserId.Id == userId && x.Status != SaleStatus.Sold)
                .FirstOrDefaultAsync();

            if (existeProductInCart == null)
                throw new NotImplementedException("Produto Não existe");

            _dbContext.ShoppingCart.Remove(existeProductInCart);
            await _dbContext.SaveChangesAsync();
        }

        public Task<IList<ShoppingCartResponse>> GetAllSold()
        {
            throw new NotImplementedException();
        }

        public Task<IList<ShoppingCartResponse>> GetAllUnsold()
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
