using System;

namespace Store.Domain.StoreContext.Commands.OrderCommands.RequestCommands
{
    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
