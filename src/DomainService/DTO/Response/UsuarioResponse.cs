
using DomainService.Enum;

namespace DomainService.DTO.Response
{
    public class UsuarioResponse
    {

        public string Nome { get; set; } 
        public sexoEnum Sexo { get; set; }
        public int Idade { get; set; }

    }
}
