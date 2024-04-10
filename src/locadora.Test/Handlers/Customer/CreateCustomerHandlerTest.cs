using locadora.Domain.Commands.Customer;
using locadora.Domain.Handlers.Customer;
using locadora.Test.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Test.Handlers.Customer
{
    [TestClass]
    public class CreateCustomerHandlerTest
    {
        [TestMethod]
        public void DadoUmClienteValido_Valid()
        {
            var command = new CreateCustomerCommand("Nome usuario", "12345678900");

            var handler = new CreateCustomerHandler(new FakeRepositoryCustomer());
            var result = handler.Handle(command).Result;

            Assert.AreEqual(0, command.Notifications.Count);
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void DadoUmClienteComCPFJaCadastrado_Invalid()
        {
            var command = new CreateCustomerCommand("Nome usuario", "12345678901");

            var handler = new CreateCustomerHandler(new FakeRepositoryCustomer());
            var result = handler.Handle(command).Result;

            Assert.AreEqual(false, result.Success);
        }
    }
}
