using Core;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Data.Repositories
{
    public class StaffTrainerRepository : Repository<StaffTrainer>, IStaffTrainerRepository
    {
        public StaffTrainerRepository(SporjoyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<StaffTrainer>> GetAllStaffTrainersAsync()
        {
            return await SporjoyDbContext.StaffTrainers
                .Include(a => a.Id)
                .ToListAsync();
        }

        public Task<StaffTrainer> GetWithStaffTrainerByIdAsync(int id)
        {
            return SporjoyDbContext.StaffTrainers
                .Include(a => a.Id)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private SporjoyDbContext SporjoyDbContext
        {
            get { return Context as SporjoyDbContext; }
        }
    }
}
