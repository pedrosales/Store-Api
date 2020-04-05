using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;
        public OrderTests()
        {
            var name = new Name("Pedro Ivo", "Sales");
            var document = new Document("09370469656");
            var email = new Email("pedroivossantos@gmail.com");
            _customer = new Customer(name, document, email, "5531994969424");
            _order = new Order(_customer);
            _mouse = new Product("Mouse Gamer", "Mouse gamer", "iamge.png", 100M, 10);
            _keyboard = new Product("Keyboard", "Keyboar gamer", "iamge.png", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Mouse gamer", "iamge.png", 100M, 10);
            _monitor = new Product("MOnitor Gamer", "Mouse gamer", "iamge.png", 100M, 10);
        }

        // Consigo criar um novo pedido
        [TestMethod]
        public void Should_Create_Order_When_Valid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void Status_Should_Be_Created_When_Order_Created()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void Should_Return_Two_When_Added_Two_Valid_Items()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);

            Assert.AreEqual(2, _order.Items.Count);
        }
        // Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void Should_Return_Five_When_Added_Purchased_Five_Item()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // Ao confirmar pedido, deve gerar um número
        [TestMethod]
        public void Should_Return_A_Number_When_Order_Placed()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void Should_Return_Paid_When_Order_Paid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dados mais 10 produtos, devem haver duas entregas
        [TestMethod]
        public void Should_Return_Two_When_Purchased_Ten_Products()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);

        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void Status_Should_Be_Canceled_When_Order_Canceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void Should_Cancel_Shippings_When_Order_Canceled()
        {
           _order.AddItem(_mouse, 1);
           _order.AddItem(_mouse, 1);
           _order.AddItem(_mouse, 1);
           _order.AddItem(_mouse, 1);
           _order.AddItem(_mouse, 1);
           _order.AddItem(_mouse, 1);
           _order.AddItem(_mouse, 1);
           _order.AddItem(_mouse, 1);
           _order.AddItem(_mouse, 1);
           _order.AddItem(_mouse, 1);
           _order.Ship();
            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
           Assert.AreEqual(2, _order.Deliveries.Count);
        }

    }
}
