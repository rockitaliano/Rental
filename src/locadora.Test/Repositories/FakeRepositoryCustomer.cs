using locadora.Domain.Interfaces.Repositories;
using locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Test.Repositories
{
    public class FakeRepositoryCustomer : ICustomerRepository
    {
        List<int> lstCustomer = new List<int>();

        public FakeRepositoryCustomer()
        {
            lstCustomer.Add(1);
            lstCustomer.Add(2);
            lstCustomer.Add(3);
            lstCustomer.Add(4);
            lstCustomer.Add(5);
            lstCustomer.Add(7);
            lstCustomer.Add(8);
            lstCustomer.Add(9);
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetByCPF(string cpf)
        {
            if (cpf == "12345678901") return await Task.FromResult(true);
            else return await Task.FromResult(false);
        }

        public  async Task<bool> GetById(int id)
        {
            var customer = lstCustomer.Contains(id);
            if (customer)
                return await Task.FromResult(true);
            else
                return await Task.FromResult(false);
        }

        public async Task<int> Save(Customer user)
        {
            return await Task.FromResult(1);
        }
    }
}
