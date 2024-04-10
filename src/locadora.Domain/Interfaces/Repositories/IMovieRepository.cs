using locadora.Domain.Models;
using locadora.Domain.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Domain.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<int> Save(Movie movie);
        Task<bool> GetByName(string name);
        Task<bool> GetById(int id);
        Task<IEnumerable<MovieAvailableQuery>> GetAll();
        Task<bool> HasAvailable(int id);
        Task UpdateSattus(int id, bool status);
    }
}
