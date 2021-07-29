using Core.Models;
using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IClubRepository: IRepository<Club>
    {
        Task<IEnumerable<Club>> GetAllClubsAsync();
        Task<Club> GetWithClubByIdAsync(int id);
    }
}
