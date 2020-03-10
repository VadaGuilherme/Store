using System;
using FluentValidator;
using Store.Domain.StoreContext.Commands.CustomerCommands.RequestCommands;
using Store.Domain.StoreContext.Commands.CustomerCommands.ResponseCommands;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommandRequest>, ICommandHandler<AddAddressCommandRequest>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommandRequest command)
        {
            if(_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            if(_repository.CheckEmail(command.Document))
                AddNotification("Email", "Este E-mail já está em uso.");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if(Invalid)
                return null;

            _repository.Save(customer);

            _emailService.Send(email.Address, "gvadaguariba@gmail.com", "Bem vindo", "Seja bem vindo");

            return new CreateCustomerCommandResponse(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommandRequest command)
        {
            throw new System.NotImplementedException();
        }
    }
}