using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using locadora.Domain.Commands.Customer;
using locadora.Domain.Core;
using locadora.Domain.Handlers.Customer;
using locadora.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace locadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CreateCustomerHandler _handler;
        private readonly ICustomerRepository _customRepository;

        public CustomerController(CreateCustomerHandler handler, ICustomerRepository customerRepository)
        {
            _handler = handler;
            _customRepository = customerRepository;
        }

        [HttpPost]
        [Route("create-customer")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
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
        [Route("getall-customer")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _customRepository.GetAll();
                var response = new ResponseCommand(true, "Lista de clientes", result);

                return Ok(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}