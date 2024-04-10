using locadora.Domain.Commands.Movie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Test.Commands.Movie
{
    [TestClass]
    public class CreateMovieCommandTest
    {
        [TestMethod]
        public void DadoUmFilmeValido_Valid()
        {
            var command = new CreateMovieCommand("Nome do Filme");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void DadoUmFilmeSemNome_Invalid()
        {
            var command = new CreateMovieCommand("");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }
    }
}
