using DomainService.DTO.Request;
using DomainService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace sebastiao.src.UI.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarios _Iusuario;
    public UsuarioController(IUsuarios iusuario)
    {
        _Iusuario = iusuario;
    }

    [HttpPost]
    public async Task<ActionResult> Post ([FromBody] UsuarioRequest request)
    {
        try
        {
            await _Iusuario.CriarPessoa(request);
            return Ok();
        }
        catch (NotImplementedException erroPost)
        {
            
           switch (erroPost.Message)
           {
                case "Dados vazio":
                    return BadRequest(erroPost);

                default:
                     return BadRequest();

           }
        }
    }
    
}
