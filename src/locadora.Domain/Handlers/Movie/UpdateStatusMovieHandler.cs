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
    public class UpdateStatusMovieHandler : ICommandHandler<UpdateStatusMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateStatusMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<ResponseCommand> Handle(UpdateStatusMovieCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return await Task.FromResult(new ResponseCommand(false, "Dados inválidos", command.Notifications));

            if (!await _movieRepository.GetById(command.MovieId))
                return await Task.FromResult(new ResponseCommand(false, "Código de filme não existe", command.MovieId));

            await _movieRepository.UpdateSattus(command.MovieId, command.Status);

            return await Task.FromResult(new ResponseCommand(true, "Status do Filme alterado com sucesso.", ""));

        }
    }
}
