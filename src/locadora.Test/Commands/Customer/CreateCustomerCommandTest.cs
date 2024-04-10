using locadora.Domain.Commands.Customer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Test.Commands.Customer
{
    [TestClass]
    public class CreateCustomerCommandTest
    {
        [TestMethod]
        public void DadoUmClienteValido_Valid()
        {
            var command = new CreateCustomerCommand("Nome do Cliente", "12345678901");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void DadoUmClienteSemNome_Invalid()
        {
            var command = new CreateCustomerCommand("", "12345678901");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmClienteSemCPF_Invalid()
        {
            var command = new CreateCustomerCommand("Nome", "");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmClienteComCPFInvalido_Invalid()
        {
            var command = new CreateCustomerCommand("Nome", "1234678");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }
    }
}
