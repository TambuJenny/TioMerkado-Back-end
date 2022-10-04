using DomainService.Interface;
using DomainService.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Account
{
    [ApiController]
    [Route("api/account/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _userInterface;

        public UserController(UserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserRequest request)
        {
            try
            {
                await _userInterface.Create(request);
                return Ok();
            }
            catch (NotImplementedException errorCreateUser)
            {
                switch (errorCreateUser.Message)
                {
                    case "Dados da pessoa existente":
                        return BadRequest(errorCreateUser.Message);

                    default:
                        return BadRequest(errorCreateUser.Message);
                }
                throw;
            }
        }
    }
}
