using Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
        private UserRepository _userRepository;
        private PlayerRepository _playerRepository;
        private ClubRepository _clubRepository;
        private StaffTrainerRepository _staffTrainerRepository;

        public UnitOfWork(SporjoyDbContext context)
        {
            this._context = context;
        }

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IPlayerRepository Players => _playerRepository = _playerRepository ?? new PlayerRepository(_context);
        public IClubRepository Clubs => _clubRepository = _clubRepository ?? new ClubRepository(_context);
        public IStaffTrainerRepository StaffTrainers => _staffTrainerRepository = _staffTrainerRepository ?? new StaffTrainerRepository(_context);


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
