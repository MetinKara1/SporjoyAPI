using Core.Models;
using Microsoft.EntityFrameworkCore;
using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SporjoyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await SporjoyDbContext.Customers
                .Include(a => a.Id)
                .ToListAsync();
        }

        public Task<Customer> GetWithCustomerByIdAsync(int id)
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
