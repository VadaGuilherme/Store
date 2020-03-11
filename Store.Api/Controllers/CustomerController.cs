using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.Entities;

namespace Store.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("")]
        public List<Customer> Get()
        {
            return null;
        }
    }
}