using locadora.Domain.Commands.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Test.Commands.User
{
    [TestClass]
    public class CreateUserCommandTest
    {
        [TestMethod]
        public void DadoUmUsuarioValido_Valid()
        {
            var command = new CreateUserCommand("user@user.com", "123456", "123456");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void DadoUmUsuarioSemEmail_Invalid()
        {
            var command = new CreateUserCommand("", "123456", "123456");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmUsuarioComSenhasDiferentes_Invalid()
        {
            var command = new CreateUserCommand("user@user.com", "1234", "123456");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmUsuarioComSenhasEmBranco_Invalid()
        {
            var command = new CreateUserCommand("user@user.com", "", "");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }

        [TestMethod]
        public void DadoUmUsuarioComSenhaPequena_Invalid()
        {
            var command = new CreateUserCommand("user@user.com", "12", "12");
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }
    }
}
