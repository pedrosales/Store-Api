using System;

namespace Store.Domain.StoreContext.OrderCommands.Inputs
{
    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}