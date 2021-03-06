using System;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.CustomerCommands.ResponseCommands
{
    public class CreateCustomerCommandResponse : ICommandResult
    {
        public CreateCustomerCommandResponse(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}