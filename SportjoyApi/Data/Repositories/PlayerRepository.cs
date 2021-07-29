using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Data.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(SporjoyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await SporjoyDbContext.Players
                .Include(a => a.Id)
                .ToListAsync();
        }

        public Task<Player> GetWithPlayerByIdAsync(int id)
        {
            return SporjoyDbContext.Players
                .Include(a => a.Id)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private SporjoyDbContext SporjoyDbContext
        {
            get { return Context as SporjoyDbContext; }
        }
    }
}
