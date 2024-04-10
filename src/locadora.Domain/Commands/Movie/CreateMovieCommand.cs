using FluentValidator;
using FluentValidator.Validation;
using locadora.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Commands.Movie
{
     public class CreateMovieCommand : Notifiable, ICommand
    {
        public string Name { get; set; }

        private CreateMovieCommand() { }

        public CreateMovieCommand(string name)
        {
            Name = name;
        }

        public void Validate()
        {
           
            AddNotifications(
               new ValidationContract()
                    .Requires()
                    .IsNotNullOrEmpty(Name, "Name", "Nome do filme é obrigatório")
            );
        }
    }
}
