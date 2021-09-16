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
    public class ClubService : IClubService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClubService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Club> CreateClub(Club newClub)
        {
            await _unitOfWork.Clubs
                .AddAsync(newClub);

            await _unitOfWork.CommitAsync();

            return newClub;
        }

        public async Task AddBranchCityAndCounty(Branchs branch, City city, County county)
        {
            await _unitOfWork.Clubs.AddBranchCityAndCountyAsync(branch, city, county);

            await _unitOfWork.CommitAsync();
        }

        public List<Branchs> GetBranchs()
        {
            return _unitOfWork.Clubs.GetBranchsAsync();
            //return data;
        }

        public List<City> GetCities()
        {
            return _unitOfWork.Clubs.GetCitiesAsync();
        }

        public List<County> GetCounties()
        {
            return _unitOfWork.Clubs.GetCountiesAsync();
        }

        public async Task DeleteClub(Club club)
        {
            _unitOfWork.Clubs.Remove(club);

            await _unitOfWork.CommitAsync();
        }

        //public async Task<Customer> ChangePassword(string password)
        //{
        //    return await _unitOfWork.Customers. SingleOrDefaultAsync(x => x.Email == customer.Email && x.Password == customer.Password);
        //}

        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            return await _unitOfWork.Clubs.GetAllClubsAsync();
        }

        public async Task<Club> GetClubById(int id)
        {
            return await _unitOfWork.Clubs.GetByIdAsync(id);
        }

        public async Task<Club> GetClubByMail(string mail)
        {
            return await _unitOfWork.Clubs.GetClubByMailAsync(mail);
        }

        public async Task UpdateClub(Club clubToBeUpdated)
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<Club> GetCommentsById(int id)
        {
            return await _unitOfWork.Clubs.GetCommentByIdAsync(id);
        }

        public async Task CreateComment(Comment comment)
        {
            await _unitOfWork.Clubs.CreateCommentAsync(comment);

            await _unitOfWork.CommitAsync();
        }

        public List<Club> GetClubByFilters(Club club) // Task<Club>
        {
            return _unitOfWork.Clubs.GetClubByFiltersAsync(club);

        }
    }
}
