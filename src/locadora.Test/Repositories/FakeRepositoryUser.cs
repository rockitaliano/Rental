using locadora.Domain.Interfaces.Repositories;
using locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Test.Repositories
{
    public class FakeRepositoryUser : IUserRepository
    {
        private User user = new User("user@user.com");
        private List<User> lstUsers = new List<User>();
        
        public FakeRepositoryUser()
        {
            lstUsers.Add(new User("user1@gmail.com"));
            lstUsers.Add(new User("user2@gmail.com"));
            lstUsers.Add(new User("user3@gmail.com"));
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.FromResult(lstUsers);
        }

        public async Task<User> GetUser(User user)
        {
            return await Task.FromResult(user);
        }

        public async Task Save(User user)
        {
            await Task.CompletedTask;
        }
    }
}