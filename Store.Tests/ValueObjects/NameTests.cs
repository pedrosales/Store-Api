using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void Should_Return_Notification_When_Name_Is_Not_Valid()
        {
            var name = new Name("", "Sales");
            Assert.AreEqual(true, name.Invalid);
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}