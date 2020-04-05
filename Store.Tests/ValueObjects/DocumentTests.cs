using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document inValidDocument;
        public DocumentTests()
        {
            validDocument = new Document("09370469656");
            inValidDocument = new Document("12345678910");
        }

        [TestMethod]
        public void Should_Return_Notification_When_Document_Is_Not_Valid()
        {
            Assert.AreEqual(false, inValidDocument.IsValid);
            Assert.AreEqual(true, inValidDocument.Invalid);
            Assert.AreEqual(1, inValidDocument.Notifications.Count);
        }

        [TestMethod]
        public void Should_Return_Not_Notification_When_Document_Is_Valid()
        {
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(false, validDocument.Invalid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
