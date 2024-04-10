using locadora.Domain.Models;
using locadora.Domain.ViewModels.Location;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Domain.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task<int> Save(Location location);
        Task<LocationQuery> GetById(int id);
        Task<bool> CustomerHasLocation(int id);
        Task DevolutionLocation(int id, DateTime date);
    }
}
