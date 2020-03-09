using System;
using System.Collections.Generic;

namespace Store.Domain.StoreContext.Commands.OrderCommands.RequestCommands
{
    public class PlaceOrderCommand
    {
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }
    }
}
