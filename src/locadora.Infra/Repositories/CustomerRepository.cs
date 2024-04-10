using Dapper;
using locadora.Domain.Interfaces.Repositories;
using locadora.Domain.Models;
using locadora.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Save(Customer customer)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var id = await sqlConn.ExecuteScalarAsync(
                    @"INSERT INTO [tb_Cliente] VALUES (@nome, @cpf)
                    SELECT SCOPE_IDENTITY()",
                        new { @nome = customer.Name, @cpf = customer.CPF});

                    return Convert.ToInt32(id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var result = await sqlConn.QueryAsync<Customer>(
                    @"SELECT 
                        ID   as Id, 
                        NOME as Name, 
                        CPF  as CPF 
                     FROM tb_Cliente");

                    return await Task.FromResult(result);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> GetById(int id)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var result = await sqlConn.ExecuteScalarAsync<bool>(
                    @"SELECT 1 FROM tb_Cliente WHERE @id = id",
                        new { @id = id });

                    return await Task.FromResult(result);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> GetByCPF(string cpf)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var result = await sqlConn.ExecuteScalarAsync<bool>(
                    @"SELECT 1 FROM tb_Cliente WHERE @cpf = cpf",
                        new { @cpf = cpf });

                    return await Task.FromResult(result);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
