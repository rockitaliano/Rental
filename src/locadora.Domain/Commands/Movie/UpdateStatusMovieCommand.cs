using FluentValidator;
using FluentValidator.Validation;
using locadora.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Commands.Movie
{
    public class UpdateStatusMovieCommand : Notifiable, ICommand
    {
        public UpdateStatusMovieCommand(int movieId, bool status)
        {
            MovieId = movieId;
            Status = status;
        }

        private UpdateStatusMovieCommand() { }

        public int MovieId { get; set; }
        public bool Status { get; set; }


        public void Validate()
        {
            if (MovieId <= 0)
                AddNotification(new Notification("MovieId", "Informe um código de filme válido"));

            AddNotifications(
               new ValidationContract()
                    .Requires()
                    .IsNotNull(Status, "Status", "Obrigatório")
            );
        }
    }
}
