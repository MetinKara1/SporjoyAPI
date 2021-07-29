using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPlayerRepository Players { get; }
        Task<int> CommitAsync();
    }
}
