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
    public class StaffTrainerService : IStaffTrainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StaffTrainerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<StaffTrainer> CreateStaffTrainer(StaffTrainer newStaffTrainer)
        {
            await _unitOfWork.StaffTrainers
                .AddAsync(newStaffTrainer);

            await _unitOfWork.CommitAsync();

            return newStaffTrainer;
        }

        public async Task DeleteStaffTrainer(StaffTrainer staffTrainer)
        {
            _unitOfWork.StaffTrainers.Remove(staffTrainer);

            await _unitOfWork.CommitAsync();
        }

        //public async Task<Customer> ChangePassword(string password)
        //{
        //    return await _unitOfWork.Customers. SingleOrDefaultAsync(x => x.Email == customer.Email && x.Password == customer.Password);
        //}

        public async Task<IEnumerable<StaffTrainer>> GetAllStaffTrainers()
        {
            return await _unitOfWork.StaffTrainers.GetAllAsync();
        }

        public async Task<StaffTrainer> GetStaffTrainerById(int id)
        {
            return await _unitOfWork.StaffTrainers.GetByIdAsync(id);
        }

        public async Task UpdateStaffTrainer(StaffTrainer staffTrainerToBeUpdated)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
