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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SporjoyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await SporjoyDbContext.Users
                .Include(a => a.Id)
                .ToListAsync();
        }

        public Task<User> GetWithUserByIdAsync(int id)
        {
            return SporjoyDbContext.Users
                .Include(a => a.Id)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private SporjoyDbContext SporjoyDbContext
        {
            get { return Context as SporjoyDbContext; }
        }
    }
}
