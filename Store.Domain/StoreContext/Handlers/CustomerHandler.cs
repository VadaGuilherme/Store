using System;
using FluentValidator;
using Store.Domain.StoreContext.Commands.CustomerCommands.RequestCommands;
using Store.Domain.StoreContext.Commands.CustomerCommands.ResponseCommands;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommandRequest>, ICommandHandler<AddAddressCommandRequest>
    {
        public ICommandResult Handle(CreateCustomerCommandRequest command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            return new CreateCustomerCommandResponse(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommandRequest command)
        {
            throw new System.NotImplementedException();
        }
    }
}