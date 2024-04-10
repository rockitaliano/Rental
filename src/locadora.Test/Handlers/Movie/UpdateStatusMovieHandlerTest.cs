using locadora.Domain.Commands.Movie;
using locadora.Domain.Handlers.Movie;
using locadora.Test.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Test.Handlers.Movie
{
    [TestClass]
     public class UpdateStatusMovieHandlerTest
    {
        [TestMethod]
        public void DadoUmaAtualizacaoValida_Valid()
        {
            var command = new UpdateStatusMovieCommand(1, true);

            var handler = new UpdateStatusMovieHandler(new FakeRepositoryMovie());
            var result = handler.Handle(command).Result;

            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void DadoUmaAtualizacaoInvalida_Invalid()
        {
            var command = new UpdateStatusMovieCommand(9, true);

            var handler = new UpdateStatusMovieHandler(new FakeRepositoryMovie());
            var result = handler.Handle(command).Result;

            Assert.AreEqual(false, result.Success);
        }
    }
}
