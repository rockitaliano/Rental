using locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task Save(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUser(User user);
    }
}
