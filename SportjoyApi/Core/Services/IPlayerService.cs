using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAllCustomers();
        Task<Player> GetCustomerById(int id);
        Task<Player> CreateCustomer(Player newCustomer);
        Task UpdateCustomer(Player customerToBeUpdated);
        Task DeleteCustomer(Player customer);
        Task<Player> ForgotPassword(Player customer);
        //Task<Customer> ChangePassword(string password);
    }
}
