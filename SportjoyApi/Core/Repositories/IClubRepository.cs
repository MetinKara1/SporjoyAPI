using Core.Models;
using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IClubRepository : IRepository<Club>
    {
        Task<IEnumerable<Club>> GetAllClubsAsync();
        Task<Club> GetWithClubByIdAsync(int id);
        Task<Club> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(Comment comment);
        List<Club> GetClubByFiltersAsync(Club club); // Task<Club>
    }
}
