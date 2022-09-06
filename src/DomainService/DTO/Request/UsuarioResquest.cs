
using DomainService.Enum;

namespace DomainService.DTO.Request
{
    public class UsuarioRequest
    {

        public string Nome { get; set; } 
        public sexoEnum Sexo { get; set; }
        public int Idade { get; set; }

    }
}
