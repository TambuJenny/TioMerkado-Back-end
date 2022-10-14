using DomaineService.Models.Request.Product;
using DomainService.Interface.Product;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Product
{
    [ApiController]
    [Route("api/product/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartInterface _shoppingCartInterface;

        public ShoppingCartController(ShoppingCartInterface shoppingCartInterface)
        {
            _shoppingCartInterface = shoppingCartInterface;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ShoppingCartRequest body)
        {
            try
            {
                await _shoppingCartInterface.Create(body);
                return Ok();
            }
            catch (NotImplementedException errorCreateshoppingCart)
            {
                switch (errorCreateshoppingCart.Message)
                {
                    case "Usuário não existe tentativa de fraude":
                        return BadRequest(errorCreateshoppingCart.Message);
                    case "Produto Já se encontra no carrinho":
                        return BadRequest(errorCreateshoppingCart.Message);
                    
                    default:
                        return BadRequest(errorCreateshoppingCart.Message);
                }

                throw;
            }
        }
    }
}
