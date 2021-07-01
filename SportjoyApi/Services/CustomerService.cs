using Core.Models;
using Core.Services;
using Sporjoy.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            await _unitOfWork.Customers 
                .AddAsync(newCustomer);

            return newCustomer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _unitOfWork.Customers.Remove(customer);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _unitOfWork.Customers.GetByIdAsync(id);
        }

        public async Task UpdateCustomer(Customer customerToBeUpdated, Customer customer)
        {
            customerToBeUpdated.Id = customer.Id;

            await _unitOfWork.CommitAsync();
        }
    }
}
