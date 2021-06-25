using Core.Models;
using Microsoft.EntityFrameworkCore;
using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SporjoyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Product>> GetAllProductssAsync()
        {
            return await SporjoyDbContext.Products
                .Include(a => a.Id)
                .ToListAsync();
        }

        public Task<Product> GetWithProductByIdAsync(int id)
        {
            return SporjoyDbContext.Products
                .Include(a => a.Id)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private SporjoyDbContext SporjoyDbContext
        {
            get { return Context as SporjoyDbContext; }
        }
    }
}
