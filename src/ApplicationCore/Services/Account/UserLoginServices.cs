using Infrastruture.Context;
using DomainService.Interface.Account;
using DomaineService.Models.Response.Login;
using Microsoft.EntityFrameworkCore;
using DomainService.Models.Enum;

namespace ApplicationCore.Services.Account
{
    public class UserLoginServices : UserLoginInterface
    {
        private DataBaseContext _dbContext;

        public UserLoginServices(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest body)
        {
            var existeUser = await _dbContext.Users
                .Where(x => x.Email == body.Email.ToLower() && x.Password == body.Password)
                .FirstOrDefaultAsync();

            if (existeUser == null)
                throw new NotImplementedException("Email ou senha incorreta");

            IList<Guid> getAllShoppingCardIdSold = await _dbContext.ShoppingCart
                .Where(x => x.UserId.Id == existeUser.Id && x.Status == SaleStatus.Sold)
                .Select(s => s.Id)
                .ToListAsync();
            
            IList<Guid> getAllShoppingCardIdCart = await _dbContext.ShoppingCart
                .Where(x => x.UserId.Id == existeUser.Id && x.Status == SaleStatus.Cart)
                .Select(s => s.Id)
                .ToListAsync();
            
             IList<Guid> getAllShoppingCardIdOrdered = await _dbContext.ShoppingCart
                .Where(x => x.UserId.Id == existeUser.Id && x.Status == SaleStatus.Ordered)
                .Select(s => s.Id)
                .ToListAsync();

            return new UserLoginResponse
            {
                Email = existeUser.Email,
                FirstName = existeUser.FirstName,
                LastName = existeUser.LastName,
                ShoppingCardIdSold = getAllShoppingCardIdSold,
                ShoppingCardIdCart = getAllShoppingCardIdCart,
                ShoppingCardIdOrdered = getAllShoppingCardIdOrdered

            };
        }
    }
}
