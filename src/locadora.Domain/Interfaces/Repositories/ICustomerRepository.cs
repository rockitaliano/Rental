using locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> Save(Customer user);
        Task<bool> GetById(int id);
        Task<IEnumerable<Customer>> GetAll();
        Task<bool> GetByCPF(string cpf);
    }
}
