using locadora.Domain.Commands.Movie;
using locadora.Domain.Contracts;
using locadora.Domain.Core;
using locadora.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Domain.Handlers.Movie
{
    public class CreateMovieHandler : ICommandHandler<CreateMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ResponseCommand> Handle(CreateMovieCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return await Task.FromResult(new ResponseCommand(false, "Dados inválidos", command.Notifications));

            if(await _movieRepository.GetByName(command.Name.ToUpper()))
                return await Task.FromResult(new ResponseCommand(false, "Já existe um filme cadastrado com esse Nome", command.Name));

            var movie = new Models.Movie(command.Name, true);

            var id = await _movieRepository.Save(movie);

            return await Task.FromResult(new ResponseCommand(true, "Filme cadastrado com sucesso",
                new { id = id, name = command.Name }));

        }
    }
}
