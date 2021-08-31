using Core.Models;
using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IStaffTrainerRepository : IRepository<StaffTrainer>
    {
        Task<IEnumerable<StaffTrainer>> GetAllStaffTrainersAsync();
        Task<StaffTrainer> GetWithStaffTrainerByIdAsync(int id);
    }
}
