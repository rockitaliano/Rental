using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Models
{
    public class User : Entity
    {
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public User() { }

        public User(string email) 
        {
            Email = email;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
