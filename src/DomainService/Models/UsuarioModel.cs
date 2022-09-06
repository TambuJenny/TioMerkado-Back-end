
using DomainService.Enum;

namespace DomainService.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; } = new Guid();
        public string Nome { get; set; } 
        public sexoEnum Sexo { get; set; }
        public int Idade { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
