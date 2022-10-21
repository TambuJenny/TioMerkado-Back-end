using DomaineService.Models.Response.Login;
using DomainService.Interface.Account;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Account
{
    [ApiController]
    [Route("api/account/[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly UserLoginInterface _userLoginInterface;

        public UserLoginController(UserLoginInterface userLoginInterface)
        {
            _userLoginInterface = userLoginInterface;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserLoginRequest request)
        {
            try
            {
                var response = await _userLoginInterface.Login(request);
                return Ok(response);
            }
            catch (NotImplementedException errorCreateUser)
            {
                switch (errorCreateUser.Message)
                {
                    case "Email ou senha incorreta":
                        return BadRequest(errorCreateUser.Message);

                    default:
                        return BadRequest(errorCreateUser.Message);
                }
                throw;
            }
        }
    }
}
