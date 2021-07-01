using Api.DTO;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class CustomerController : BaseAPIController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController (ICustomerService customerService, IMapper mapper)
        {
            this._customerService = customerService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            var customerResources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);

            return Ok(customerResources);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> CreateCustomer(Customer customer)
        {
            var createCustomer = await _customerService.CreateCustomer(customer);

            return Ok(createCustomer);
        }
    }
}
