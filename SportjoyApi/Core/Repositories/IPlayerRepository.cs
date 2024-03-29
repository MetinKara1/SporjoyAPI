﻿using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Core.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<Player> GetWithPlayerByIdAsync(int id);
    }
}
