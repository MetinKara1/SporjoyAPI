using Core.Repositories;
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
        IClubRepository Clubs { get; }
        IStaffTrainerRepository StaffTrainers { get; }
        Task<int> CommitAsync();
    }
}
