using locadora.Domain.Handlers.Customer;
using locadora.Domain.Handlers.Location;
using locadora.Domain.Handlers.Movie;
using locadora.Domain.Handlers.User;
using locadora.Domain.Interfaces.Repositories;
using locadora.Infra.Context;
using locadora.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadora.API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //DataContext
            services.AddScoped<DataContext>();

            //Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //Handlers
            //Customer
            services.AddScoped<CreateCustomerHandler>();

            //Movies
            services.AddScoped<CreateMovieHandler>();
            services.AddScoped<UpdateStatusMovieHandler>();

            //Location
            services.AddScoped<CreateLocationHandler>();
            services.AddScoped<DevolutionLocationHandler>();

            //User
            services.AddScoped<UserHandler>();

            return services;
        }
    }
}
