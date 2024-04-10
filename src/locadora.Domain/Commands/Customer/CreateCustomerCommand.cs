
using FluentValidator;
using FluentValidator.Validation;
using locadora.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace locadora.Domain.Commands.Customer
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string CPF { get; set; }

        private CreateCustomerCommand() { }

        public CreateCustomerCommand(string name, string cpf)
        {
            Name = name;
            CPF = cpf;
        }     

        public void Validate()
        {
            if (CPF.Length != 11)
                AddNotification(new Notification(CPF, "Número de CPF inválido"));

            AddNotifications(
               new ValidationContract()
                    .Requires()
                    .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatório")
                    .IsNotNullOrEmpty(CPF, "CPF", "CPF é obrigatório")
            );
        }
    }
}
