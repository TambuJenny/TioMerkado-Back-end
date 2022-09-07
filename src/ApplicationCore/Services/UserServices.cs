using AutoMapper;
using DomainService.Interface;
using DomainService.Models;
using DomainService.Models.Request;
using Infrastruture.Context;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCore.Services
{
    public class UserServices : UserInterface
    {
        private readonly DataBaseContext _dbContext;

        private readonly IMapper _mapper;

        public UserServices(DataBaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Create(UserRequest body)
        {
            var existe = (
                from u in _dbContext.Users
                where u.Email == body.Email && body.PhoneNumber == u.PhoneNumber
                select u
            ).Any();

            if (existe)
                throw new NotImplementedException("Dados da pessoa existente");

            await _dbContext.Users.AddAsync(_mapper.Map<UserModel>(body));
            await _dbContext.SaveChangesAsync();
        }
    }
}
