using locadora.Domain.Commands.Location;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Test.Commands.Location
{
    [TestClass]
    public class CreateLocationCommandTest
    {
        [TestMethod]
        public void DadoUmaLocacaolValida_Valid()
        {
            var command = new CreateLocationCommand(1, 1);
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void DadoUmaLocacaolSemCliente_Invalid()
        {
            var command = new CreateLocationCommand(0,1);
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmaLocacaolSemFilme_Invalid()
        {
            var command = new CreateLocationCommand(1, 0);
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmaLocacaolSemFilmeSemCliente_Invalid()
        {
            var command = new CreateLocationCommand(0, 0);
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }
    }
}
