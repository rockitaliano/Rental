using locadora.Domain.Commands.User;
using locadora.Domain.Handlers.User;
using locadora.Test.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Test.Handlers.User
{
    [TestClass]
    public class UserHandlerTest
    {
        [TestMethod]
        public void DadoUmUsuarioValido_Valid()
        {
            var command = new CreateUserCommand("user@mail.com", "1234", "1234");

            var handler = new UserHandler(new FakeRepositoryUser());
            var result = handler.Handle(command).Result;

            Assert.AreEqual(true, result.Success);
        }
    }
}
