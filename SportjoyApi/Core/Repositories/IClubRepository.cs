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
        Task<Club> GetClubByMailAsync(string mail);
        Task<Club> GetCommentByIdAsync(int id);
        List<Branchs> GetBranchsAsync();
        List<City> GetCitiesAsync();
        List<County> GetCountiesAsync();
        Task CreateCommentAsync(Comment comment);
        Task AddBranchCityAndCountyAsync(Branchs branch, City city, County county);
        List<Club> GetClubByFiltersAsync(Club club); // Task<Club>
    }
}
