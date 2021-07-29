using Core;
using Core.Models;
using Core.Services;
using Sporjoy.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Player> CreatePlayer(Player newPlayer)
        {
            await _unitOfWork.Players 
                .AddAsync(newPlayer);

            await _unitOfWork.CommitAsync();

            return newPlayer;
        }

        public async Task DeletePlayer(Player player)
        {
            _unitOfWork.Players.Remove(player);

            await _unitOfWork.CommitAsync();
        }

        //public async Task<Customer> ChangePassword(string password)
        //{
        //    return await _unitOfWork.Customers. SingleOrDefaultAsync(x => x.Email == customer.Email && x.Password == customer.Password);
        //}

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _unitOfWork.Players.GetAllAsync();
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return await _unitOfWork.Players.GetByIdAsync(id);
        }

        public async Task UpdatePlayer(Player playerToBeUpdated)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
