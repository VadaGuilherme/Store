using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.Commands.CustomerCommands.RequestCommands;
using Store.Domain.StoreContext.Commands.CustomerCommands.ResponseCommands;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Shared.Commands;

namespace Store.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository customerRepository, CustomerHandler customerHandler)
        {
            _customerRepository = customerRepository;
            _handler = customerHandler;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _customerRepository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _customerRepository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _customerRepository.GetOrders(id);
        }

        [HttpPost]
        [Route("customers")]
        public CreateCustomerCommandResponse Post([FromBody]CreateCustomerCommandRequest command)
        {
            var result = (CreateCustomerCommandResponse)_handler.Handle(command);
            
            return result;
        }
    }
}