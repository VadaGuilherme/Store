using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.CustomerCommands.RequestCommands;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommandRequest();

            command.FirstName = "Guilherme";
            command.LastName = "Vada";
            command.Document = "81776778022";
            command.Email = "gvadaguariba@gmail.com";
            command.Phone = "16999999999";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
