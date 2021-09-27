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
        Task<Club> GetClubByMail(string mail);
        List<Club> GetClubByFilters(Club club); // Task<Club>
        Task<Club> GetCommentsById(int id);
        List<Branchs> GetBranchs();
        List<City> GetCities();
        List<County> GetCounties();
        Task CreateComment(Comment comment);
        Task AddPhotos(ICollection<Photos> photos);
        Task AddBranchCityAndCounty(Branchs branch, City city, County county);
        Task<Club> CreateClub(Club newClub);
        Task UpdateClub(Club clubToBeUpdated);
        Task DeleteClub(Club club);
    }
}
