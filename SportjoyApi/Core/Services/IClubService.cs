using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IClubService
    {
        Task<IEnumerable<Club>> GetAllClubs();
        Task<Club> GetClubById(int id);
        List<Club> GetClubByFilters(Club club); // Task<Club>
        Task<Club> GetCommentsById(int id);
        Task CreateComment(Comment comment);
        Task<Club> CreateClub(Club newClub);
        Task UpdateClub(Club clubToBeUpdated);
        Task DeleteClub(Club club);
    }
}
