using locadora.Domain.Commands.Location;
using locadora.Domain.Contracts;
using locadora.Domain.Core;
using locadora.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Domain.Handlers.Location
{
    public class CreateLocationHandler : ICommandHandler<CreateLocationCommand>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILocationRepository _locationRepository;

        public CreateLocationHandler(IMovieRepository movieRepository, ICustomerRepository customerRepository, 
                                     ILocationRepository locationRepository)
        {
            _movieRepository = movieRepository;
            _customerRepository = customerRepository;
            _locationRepository = locationRepository;
        }

        public async Task<ResponseCommand> Handle(CreateLocationCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return await Task.FromResult(new ResponseCommand(false, "Dados inválidos", command.Notifications));

            if(!await _customerRepository.GetById(command.CustomerId))
                return await Task.FromResult(new ResponseCommand(false, "Código de cliente não exite", command.CustomerId));

            if (!await _movieRepository.GetById(command.MovieId))
                return await Task.FromResult(new ResponseCommand(false, "Código de filme não existe", command.MovieId));

            if(!await _movieRepository.HasAvailable(command.MovieId))
                return await Task.FromResult(new ResponseCommand(false, "Desculpe, Filme indisponível no momento", ""));

            if (await _locationRepository.CustomerHasLocation(command.CustomerId))
                return await Task.FromResult(new ResponseCommand(false, "Cliente possui locações em aberto. Locação não efetuada", command.MovieId));

            var location = new Models.Location(command.CustomerId, command.MovieId, DateTime.Now.Date, DateTime.Now.Date.AddDays(2));

            var id = await _locationRepository.Save(location);

            var response = await _locationRepository.GetById(id);

            return await Task.FromResult(new ResponseCommand(true, "Operação efetuada com sucesso.",
                    new {   
                            ComprovanteLocacao = response.Id,
                            NomeCliente = response.CustomerName,
                            NomeFilme = response.MovieName,
                            DataLocacao = response.LocationDate.ToString("dd/MM/yyyy"),
                            DataDevolucao = response.DevolutionDate.ToString("dd/MM/yyyy")
                    }
                ));
        }
    }
}
