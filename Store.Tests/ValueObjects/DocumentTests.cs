using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document VALIDDOCUMENT;
        private Document INVALIDDOCUMENT;
        public DocumentTests()
        {
            VALIDDOCUMENT = new Document("81776778022");
            INVALIDDOCUMENT = new Document("1234567891011");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, VALIDDOCUMENT.IsValid);
            Assert.AreEqual(0, VALIDDOCUMENT.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, INVALIDDOCUMENT.IsValid);
            Assert.AreEqual(1, INVALIDDOCUMENT.Notifications.Count);
        }
    }
}