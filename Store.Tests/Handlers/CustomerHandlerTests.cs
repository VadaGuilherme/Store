using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.CustomerCommands.RequestCommands;
using Store.Domain.StoreContext.Handlers;
using Store.Tests.Fakes;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommandRequest();

            command.FirstName = "Guilherme";
            command.LastName = "Vada";
            command.Document = "81776778022";
            command.Email = "gvadaguariba@gmail.com";
            command.Phone = "16999999999";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}