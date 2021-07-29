using Core;
using Core.Models;
using Core.Services;
using Sporjoy.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users 
                .AddAsync(newUser);

            await _unitOfWork.CommitAsync();

            return newUser;
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);

            await _unitOfWork.CommitAsync();
        }

        public async Task<User> ForgotPassword(User user)
        {
            return await _unitOfWork.Users.SingleOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
        }

        //public async Task<Customer> ChangePassword(string password)
        //{
        //    return await _unitOfWork.Customers. SingleOrDefaultAsync(x => x.Email == customer.Email && x.Password == customer.Password);
        //}

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task UpdateUser(User userToBeUpdated)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
