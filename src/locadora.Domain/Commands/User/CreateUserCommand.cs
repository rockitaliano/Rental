using FluentValidator;
using FluentValidator.Validation;
using locadora.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Commands.User
{
    public class CreateUserCommand : Notifiable, ICommand
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public CreateUserCommand(string email, string password, string confirmPassword)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        private CreateUserCommand() { }

        public void Validate()
        {
            if (Password != ConfirmPassword)
                AddNotification(new Notification("Register", "Os campos de senha não conferem"));

            AddNotifications(
              new ValidationContract()
                   .Requires()
                   .HasMinLen(Password, 3, "Password", " A senha deve ter no mínimo 3 caracteres!")
                   .IsNotNullOrEmpty(Email, Email, "Email obrigatório")
           ); ;
        }
    }
}
