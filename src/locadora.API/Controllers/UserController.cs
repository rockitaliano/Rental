using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using locadora.API.Services;
using locadora.API.ViewModels;
using locadora.Domain.Commands.User;
using locadora.Domain.Core;
using locadora.Domain.Handlers.User;
using locadora.Domain.Interfaces.Repositories;
using locadora.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace locadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserHandler _handler;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserController(UserHandler handler, IUserRepository userRepository, IConfiguration configuration)
        {
            _handler = handler;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ResponseCommand> Create([FromBody] CreateUserCommand command)
        {
            try
            {
                var result = await _handler.Handle(command);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ResponseCommand> Login([FromBody] UserCommandDTO userCommand)
        {
            try
            {
                var userCreate = new User(userCommand.Email, userCommand.Password);
                var user = await _userRepository.GetUser(userCreate);

                if (user == null)
                    return new ResponseCommand(false, "Usuário ou Senha invalidos", new { userCommand.Email });

                var instaceToken = new TokenService(_configuration);
                var token = await instaceToken.GenerateToken(user);

                return new ResponseCommand(true, "Login efetuado com sucesso.", token);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        [HttpGet]
        [Route("return-users")]
        [Authorize]
        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                var result = await _userRepository.GetAll();

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


    }
}