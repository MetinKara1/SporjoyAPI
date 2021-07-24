using Core.Models;
using Microsoft.EntityFrameworkCore;
using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Data.Repositories
{
    public class CustomerRepository : Repository<Player>, IPlayerRepository
    {
        public CustomerRepository(SporjoyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Player>> GetAllCustomersAsync()
        {
            return await SporjoyDbContext.Customers
                .Include(a => a.Id)
                .ToListAsync();
        }

        public Task<Player> GetWithCustomerByIdAsync(int id)
        {
            return SporjoyDbContext.Customers
                .Include(a => a.Id)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private SporjoyDbContext SporjoyDbContext
        {
            get { return Context as SporjoyDbContext; }
        }
    }
}
