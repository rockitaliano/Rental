using locadora.Domain.Interfaces.Repositories;
using locadora.Domain.Models;
using locadora.Domain.ViewModels.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace locadora.Test.Repositories
{
    public class FakeRepositoryLocation : ILocationRepository
    {
        private LocationQuery _location1;
        private LocationQuery _location2;
        private LocationQuery _location3;
        private LocationQuery _location4;
        private LocationQuery _location5;

        private List<LocationQuery> lstLocation;

        public async Task<bool> CustomerHasLocation(int id)
        {
            if (id == 2) return await Task.FromResult(true);
            else return await Task.FromResult(false); ;
        }

        public async Task DevolutionLocation(int id, DateTime date)
        {
            await Task.CompletedTask;
        }

        public async Task<LocationQuery> GetById(int id)
        {
            var lstLocations = await GetLocationList();
            var location = lstLocation.Where(l => l.Id == id).FirstOrDefault();

            return await Task.FromResult(location);
        }

        public async Task<int> Save(Location location)
        {
            return await Task.FromResult(1);
        }

        private async Task<List<LocationQuery>> GetLocationList()
        {
            lstLocation = new List<LocationQuery>();

            _location1 = new LocationQuery();
            _location1.Id = 1;
            _location1.CustomerName = "Nome do cliente 1";
            _location1.MovieName = "Nome do Filme 1";
            _location1.LocationDate = DateTime.Now.Date;
            _location1.DevolutionDate = DateTime.Now.Date.AddDays(2);

            _location2 = new LocationQuery();
            _location2.Id = 2;
            _location2.CustomerName = "Nome do cliente 2";
            _location2.MovieName = "Nome do Filme 2";
            _location2.LocationDate = DateTime.Now.Date;
            _location2.DevolutionDate = DateTime.Now.Date.AddDays(2);

            _location3 = new LocationQuery();
            _location3.Id = 3;
            _location3.CustomerName = "Nome do cliente 3";
            _location3.MovieName = "Nome do Filme 3";
            _location3.LocationDate = DateTime.Now.Date;
            _location3.DevolutionDate = DateTime.Now.Date.AddDays(2);

            _location4 = new LocationQuery();
            _location4.Id = 4;
            _location4.CustomerName = "Nome do cliente 4";
            _location4.MovieName = "Nome do Filme 4";
            _location4.LocationDate = DateTime.Now.Date;
            _location4.DevolutionDate = DateTime.Now.Date.AddDays(2);

            _location5 = new LocationQuery();
            _location5.Id = 5;
            _location5.CustomerName = "Nome do cliente 5";
            _location5.MovieName = "Nome do Filme 5";
            _location5.LocationDate = DateTime.Now.Date.AddDays(-10);
            _location5.DevolutionDate = DateTime.Now.Date.AddDays(-5);

            lstLocation.Add(_location1);
            lstLocation.Add(_location2);
            lstLocation.Add(_location3);
            lstLocation.Add(_location4);
            lstLocation.Add(_location5);

            return await Task.FromResult(lstLocation);
        }
    }
}
