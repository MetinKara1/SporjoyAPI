using Sporjoy.Core;
using Sporjoy.Core.Repositories;
using Sporjoy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SporjoyDbContext _context;
        private CustomerRepository _customerRepository;

        public UnitOfWork(SporjoyDbContext context)
        {
            this._context = context;
        }

        public IPlayerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
