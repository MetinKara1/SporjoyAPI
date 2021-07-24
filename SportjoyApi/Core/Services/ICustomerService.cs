using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer customerToBeUpdated);
        Task DeleteCustomer(Customer customer);
        Task<Customer> ForgotPassword(Customer customer);
        //Task<Customer> ChangePassword(string password);
    }
}
