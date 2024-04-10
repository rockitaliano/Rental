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
    public class CreateMovieHandlerTest
    {
        [TestMethod]
        public void DadoUmFilmeValido_Valid()
        {
            var command = new CreateMovieCommand("Novo Filme");

            var handler = new CreateMovieHandler(new FakeRepositoryMovie());
            var result = handler.Handle(command).Result;

            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void DadoUmFilmeJaCadastrado_Invalid()
        {
            var command = new CreateMovieCommand("CADASTRADO");

            var handler = new CreateMovieHandler(new FakeRepositoryMovie());
            var result = handler.Handle(command).Result;

            Assert.AreEqual(false, result.Success);
        }
    }
}
