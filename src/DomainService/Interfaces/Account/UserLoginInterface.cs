using DomaineService.Models.Response.Login;

namespace DomainService.Interface.Account
{
    public interface UserLoginInterface
    {
        Task<UserLoginResponse> Login(UserLoginRequest body);
    }
}
