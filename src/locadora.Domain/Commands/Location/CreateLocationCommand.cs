using FluentValidator;
using locadora.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Commands.Location
{
    public class CreateLocationCommand : Notifiable, ICommand
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        
        private CreateLocationCommand() { }

        public CreateLocationCommand(int customerId, int movieId)
        {
            CustomerId = customerId;
            MovieId = movieId;
        }

        public void Validate()
        {
            if(CustomerId <= 0)
                AddNotification(new Notification("CustomerId", "Informe um código de cliente válido"));

            if (MovieId <= 0)
                AddNotification(new Notification("MovieId", "Informe um código de filme válido"));
        }
    }
}
