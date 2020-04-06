using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Handlers;
using Store.Tests.Fakes;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void Should_Register_Customer_When_Command_Is_Valid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Pedro Ivo";
            command.LastName = "Sales";
            command.Document = "09370469656";
            command.Email = "pedroivossantos@gmail.com";
            command.Phone = "31994969424";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}