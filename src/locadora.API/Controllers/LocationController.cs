using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using locadora.Domain.Commands.Location;
using locadora.Domain.Handlers.Location;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace locadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly CreateLocationHandler _handler;
        private readonly DevolutionLocationHandler _handlerDevolution;

        public LocationController(CreateLocationHandler handler, DevolutionLocationHandler handlerDevolution)
        {
            _handler = handler;
            _handlerDevolution = handlerDevolution;
        }

        [HttpPost]
        [Route("v1/create-location")]
        [Authorize]

        public async Task<IActionResult> Create([FromBody] CreateLocationCommand command)
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
        [HttpPost]
        [Route("v2/create-location")]
        [Authorize]
        public async Task<IActionResult> CreateNewVersion([FromBody] CreateLocationCommand command)
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

        [HttpPost]
        [Route("delovution-location")]
        [Authorize]
        public async Task<IActionResult> Devolution([FromBody] DevolutionLocationCommand command)
        {
            try
            {
                var result = await _handlerDevolution.Handle(command);

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