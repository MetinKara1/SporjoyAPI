using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICustomerRepository Customers { get; }
        Task<int> CommitAsync();
    }
}
