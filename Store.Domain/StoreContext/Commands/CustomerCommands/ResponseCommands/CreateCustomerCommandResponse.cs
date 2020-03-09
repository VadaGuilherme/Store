using System;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.CustomerCommands.ResponseCommands
{
    public class CreateCustomerCommandResponse : ICommandResult
    {
        public CreateCustomerCommandResponse()
        {
            
        }
        public CreateCustomerCommandResponse(Guid id, string Name, string email)
        {
            Id = id;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}