using locadora.Domain.Commands.Customer;
using locadora.Domain.Contracts;
using locadora.Domain.Core;
using locadora.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Domain.Handlers.Customer
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ResponseCommand> Handle(CreateCustomerCommand command)
        {
            try
            {
                command.Validate();
                if (command.Invalid)
                    return await Task.FromResult(new ResponseCommand(false, "Dados inválidos", command.Notifications));

                if (await _customerRepository.GetByCPF(command.CPF))
                    return await Task.FromResult(new ResponseCommand(false, "Já existe um cliente cadastrado com esse CPF", command.CPF));

                var customer = new Models.Customer(command.Name, command.CPF);

                var id = await _customerRepository.Save(customer);

                return await Task.FromResult(new ResponseCommand(true, "Cliente cadastrado com sucesso", 
                    new { id = id, name = command.Name, cpf = command.CPF }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
