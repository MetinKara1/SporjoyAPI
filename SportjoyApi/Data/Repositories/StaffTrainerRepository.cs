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
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        public ClubRepository(SporjoyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Club>> GetAllClubsAsync()
        {
            return await SporjoyDbContext.Clubs
                .Include(a => a.Id)
                .ToListAsync();
        }

        public Task<Club> GetWithClubByIdAsync(int id)
        {
            return SporjoyDbContext.Clubs
                .Include(a => a.Id)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private SporjoyDbContext SporjoyDbContext
        {
            get { return Context as SporjoyDbContext; }
        }
    }
}
