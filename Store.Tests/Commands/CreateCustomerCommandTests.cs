using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.CustomerCommands.Inputs;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void Should_Validate_When_Command_Is_Valid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Pedro Ivo";
            command.LastName = "Sales";
            command.Document = "09370469656";
            command.Email = "pedroivossantos@gmail.com";
            command.Phone = "5531994969424";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
