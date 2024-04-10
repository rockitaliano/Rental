using locadora.Domain.Commands.Location;
using locadora.Domain.Handlers.Location;
using locadora.Test.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Test.Handlers.Location
{
    [TestClass]
    public class DevolutionLocationHandlerTest
    {
        [TestMethod]
        public void DadoUmaDevolucaoValida_Valid()
        {
            var command = new DevolutionLocationCommand(1);

            var handler = new DevolutionLocationHandler(new FakeRepositoryLocation());

            var result = handler.Handle(command).Result;

            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void DadoUmaDevolucaoComNumeroInvalido_Invalid()
        {
            var command = new DevolutionLocationCommand(6);

            var handler = new DevolutionLocationHandler(new FakeRepositoryLocation());

            var result = handler.Handle(command).Result;

            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void DadoUmaDevolucaoComAtrasoValida_Valid()
        {
            var command = new DevolutionLocationCommand(5);

            var handler = new DevolutionLocationHandler(new FakeRepositoryLocation());

            var result = handler.Handle(command).Result;

            Assert.AreEqual(true, result.Success);
            Assert.AreEqual(true, result.Data.ToString().Contains("ATENÇÃO"));

        }

        [TestMethod]
        public void DadoUmaDevolucaoSemAtrasoValida_Valid()
        {
            var command = new DevolutionLocationCommand(1);

            var handler = new DevolutionLocationHandler(new FakeRepositoryLocation());

            var result = handler.Handle(command).Result;

            Assert.AreEqual(true, result.Success);
            Assert.AreEqual("", result.Data.ToString());

        }
    }
}
