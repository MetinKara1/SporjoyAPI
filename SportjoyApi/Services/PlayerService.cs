using Core.Models;
using Core.Services;
using Sporjoy.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Player> CreateCustomer(Player newCustomer)
        {
            await _unitOfWork.Customers 
                .AddAsync(newCustomer);

            await _unitOfWork.CommitAsync();

            return newCustomer;
        }

        public async Task DeleteCustomer(Player customer)
        {
            _unitOfWork.Customers.Remove(customer);

            await _unitOfWork.CommitAsync();
        }

        public async Task<Player> ForgotPassword(Player customer)
        {
            return await _unitOfWork.Customers.SingleOrDefaultAsync(x => x.Email == customer.Email && x.Password == customer.Password);
        }

        //public async Task<Customer> ChangePassword(string password)
        //{
        //    return await _unitOfWork.Customers. SingleOrDefaultAsync(x => x.Email == customer.Email && x.Password == customer.Password);
        //}

        public async Task<IEnumerable<Player>> GetAllCustomers()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        public async Task<Player> GetCustomerById(int id)
        {
            return await _unitOfWork.Customers.GetByIdAsync(id);
        }

        public async Task UpdateCustomer(Player customerToBeUpdated)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
