using FluentValidator;
using locadora.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Commands.Location
{
    public class DevolutionLocationCommand : Notifiable, ICommand
    {
        public DevolutionLocationCommand(int locationId)
        {
            LocationId = locationId;
        }

        public DevolutionLocationCommand() { }

        public int LocationId { get; set; }

        public void Validate()
        {
            if (LocationId <= 0)
                AddNotification(new Notification("LocationId", "Informe um código de locação válido"));
        }
    }
}
