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
    public class CreateLocationHandlerTest
    {
        [TestMethod]
        public void DadoUmFilmeValido_Valid()
        {
            var command = new CreateLocationCommand(1, 1);

            var handler = new CreateLocationHandler(new FakeRepositoryMovie(),
                                                    new FakeRepositoryCustomer(),
                                                    new FakeRepositoryLocation());

            var result = handler.Handle(command).Result;

            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void DadoUmClienteComLocacoesPendentes_Invalid()
        {
            var command = new CreateLocationCommand(2, 1);

            var handler = new CreateLocationHandler(new FakeRepositoryMovie(),
                                                    new FakeRepositoryCustomer(),
                                                    new FakeRepositoryLocation());

            var result = handler.Handle(command).Result;

            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void DadoUmFilmeIndisponivel_Invalid()
        {
            var command = new CreateLocationCommand(1, 2);

            var handler = new CreateLocationHandler(new FakeRepositoryMovie(),
                                                    new FakeRepositoryCustomer(),
                                                    new FakeRepositoryLocation());

            var result = handler.Handle(command).Result;

            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void DadoUmClienteNaoExiste_Invalid()
        {
            var command = new CreateLocationCommand(10, 1);

            var handler = new CreateLocationHandler(new FakeRepositoryMovie(),
                                                    new FakeRepositoryCustomer(),
                                                    new FakeRepositoryLocation());

            var result = handler.Handle(command).Result;

            Assert.AreEqual(false, result.Success);
        }
    }
}
