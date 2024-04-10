using locadora.Domain.Commands.Location;
using locadora.Domain.Contracts;
using locadora.Domain.Core;
using locadora.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Domain.Handlers.Location
{
    public class DevolutionLocationHandler : ICommandHandler<DevolutionLocationCommand>
    {
        private readonly ILocationRepository _locationRepository;

        public DevolutionLocationHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<ResponseCommand> Handle(DevolutionLocationCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return await Task.FromResult(new ResponseCommand(false, "Dados inválidos", command.Notifications));

            var location = await _locationRepository.GetById(command.LocationId);

            if (location == null)
                return await Task.FromResult(new ResponseCommand(false, "Numero de locação não encontrado", command.Notifications));

            await _locationRepository.DevolutionLocation(command.LocationId, DateTime.Now.Date);

            if (DateTime.Now.Date > location.DevolutionDate) 
            {
                TimeSpan date = Convert.ToDateTime(DateTime.Now.Date) - Convert.ToDateTime(location.DevolutionDate);
                return await Task.FromResult(new ResponseCommand(true, "Devolução feita com sucesso", 
                                             $"ATENÇÃO: Devolução efetuada com {date.Days} dias de atraso"));
            }
            else
            {
                return await Task.FromResult(new ResponseCommand(true, "Devolução feita com sucesso", ""));
            }
        }
    } 
}


