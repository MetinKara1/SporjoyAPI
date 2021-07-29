using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<Player> GetPlayerById(int id);
        Task<Player> CreatePlayer(Player newPlayer);
        Task UpdatePlayer(Player playerToBeUpdated);
        Task DeletePlayer(Player player);
    }
}
