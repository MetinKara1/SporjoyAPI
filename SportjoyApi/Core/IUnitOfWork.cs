using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Customers { get; }
        Task<int> CommitAsync();
    }
}
