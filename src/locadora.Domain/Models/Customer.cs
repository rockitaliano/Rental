using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Models
{
    public class Customer
    {
        public Customer(string name, string cpf)
        {
            Name = name;
            CPF = cpf;
        }

        private Customer()
        {

        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
    }
}
