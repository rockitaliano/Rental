using locadora.Domain.Commands.Movie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Test.Commands.Movie
{
    [TestClass]
    public class UpdateStatusMovieCommandTest
    {
        [TestMethod]
        public void DadoUmaAlteracaoDisponivelValida_Valid()
        {
            var command = new UpdateStatusMovieCommand(1, true);
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void DadoUmaAlteracaoIndisponivelValida_Valid()
        {
            var command = new UpdateStatusMovieCommand(1, false);
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void DadoUmaAlteracaoSemFilme_Invalid()
        {
            var command = new UpdateStatusMovieCommand(0, false);
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

    }
}
