using FluentValidator;
using FluentValidator.Validation;
using locadora.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadora.API.ViewModels
{
    public class UserCommandDTO : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
              new ValidationContract()
                   .Requires()
                   .IsNullOrEmpty(Email, Email, " Campo e-mail é obrigatório")
                   .IsNullOrEmpty(Password, Password, " Campo senha é obrigatório")
           );
        }
    }
}
