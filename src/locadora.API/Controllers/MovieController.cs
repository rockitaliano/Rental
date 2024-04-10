using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using locadora.Domain.Commands.Movie;
using locadora.Domain.Core;
using locadora.Domain.Handlers.Movie;
using locadora.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace locadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly CreateMovieHandler _handler;
        private readonly UpdateStatusMovieHandler _handlerUpdateStatus;
        private readonly IMovieRepository _movieRepository;

        public MovieController(CreateMovieHandler handler, UpdateStatusMovieHandler handlerUpdateStatus, IMovieRepository movieRepository)
        {
            _handler = handler;
            _handlerUpdateStatus = handlerUpdateStatus;
            _movieRepository = movieRepository;
        }

        [HttpPost]
        [Route("create-movie")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateMovieCommand command)
        {
            try
            {
                var result = await _handler.Handle(command);

                if (command.Notifications.Any())
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("getall-movie")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _movieRepository.GetAll();
                var response = new ResponseCommand(true, "Lista de Filmes", result);

                return Ok(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        [Route("update-status-movie")]
        [Authorize]
        public async Task<IActionResult> UpadateStatus([FromBody] UpdateStatusMovieCommand command)
        {
            try
            {
                var result = await _handlerUpdateStatus.Handle(command);

                if (command.Notifications.Any())
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}