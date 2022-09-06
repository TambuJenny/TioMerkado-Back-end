using AutoMapper;
using DomainService.DTO.Request;
using DomainService.DTO.Response;
using DomainService.Interfaces;
using DomainService.Models;
using Infrastruture.Context;

namespace AplicationCore.Services
{
    public class UsuarioServices : IUsuarios
    {

        private readonly DataBaseContext _databaseContext;
        private IMapper _mapper;

        public UsuarioServices(DataBaseContext databaseContext,IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public Task ApagarPessoa(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarPessoa(UsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task CriarPessoa(UsuarioRequest request)
        {
            if(request == null)
                 throw new NotImplementedException("Dados vazio");

            var usuario = new UsuarioModel();
            usuario.Idade = request.Idade;
            usuario.Nome = request.Nome;
            usuario.Sexo = request.Sexo;

            await  _databaseContext.Usuarios.AddAsync(usuario);
            await  _databaseContext.SaveChangesAsync();
            

        }

        public Task<List<UsuarioResponse>> ListarTodasPessoas()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioResponse> PegarUmaPessoa(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
