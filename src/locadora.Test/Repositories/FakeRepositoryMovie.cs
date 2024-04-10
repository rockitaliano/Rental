using locadora.Domain.Interfaces.Repositories;
using locadora.Domain.Models;
using locadora.Domain.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Test.Repositories
{
    public class FakeRepositoryMovie : IMovieRepository
    {
        List<int> lstMovie = new List<int>();

        public FakeRepositoryMovie()
        {
            lstMovie.Add(1);
            lstMovie.Add(2);
            lstMovie.Add(3);
            lstMovie.Add(4);
            lstMovie.Add(5);
            lstMovie.Add(6);
        }

        public Task<IEnumerable<MovieAvailableQuery>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetById(int id)
        {
            var movie = lstMovie.Contains(id);
            if (movie)
                return await Task.FromResult(true);
            else
                return await Task.FromResult(false);
        }

        public async Task<bool> GetByName(string name)
        {
            if (name == "CADASTRADO") return await Task.FromResult(true);
            else return await Task.FromResult(false);
        }

        public async Task<bool> HasAvailable(int id)
        {
            if (id == 1) return await Task.FromResult(true);
            else return await Task.FromResult(false);
        }

        public async Task<int> Save(Movie movie)
        {
            return await Task.FromResult(1);
        }

        public async Task UpdateSattus(int id, bool status)
        {
            await Task.CompletedTask;
        }
    }
}
