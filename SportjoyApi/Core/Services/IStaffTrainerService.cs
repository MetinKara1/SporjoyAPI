using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IStaffTrainerService
    {
        Task<IEnumerable<StaffTrainer>> GetAllStaffTrainers();
        Task<StaffTrainer> GetStaffTrainerById(int id);
        Task<StaffTrainer> CreateStaffTrainer(StaffTrainer newStaffTrainer);
        Task UpdateStaffTrainer(StaffTrainer staffTrainerToBeUpdated);
        Task DeleteStaffTrainer(StaffTrainer staffTrainer);
    }
}
