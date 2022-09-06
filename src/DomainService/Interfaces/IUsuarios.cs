using DomainService.DTO.Request;
using DomainService.DTO.Response;

namespace DomainService.Interfaces
{
    public interface IUsuarios
    {
       Task CriarPessoa  (UsuarioRequest request);
       Task AtualizarPessoa  (UsuarioRequest request);
       Task ApagarPessoa (Guid id);
       Task<UsuarioResponse> PegarUmaPessoa (Guid id);
       Task<List<UsuarioResponse>> ListarTodasPessoas();

    }
}
