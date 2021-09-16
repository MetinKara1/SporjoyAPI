using Core;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Sporjoy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Data.Repositories
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        public ClubRepository(SporjoyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Club>> GetAllClubsAsync()
        {

            var test = await SporjoyDbContext.Clubs
                //.Include(a => a.Id)
                .ToListAsync();

            return test;
        }

        public Task<Club> GetWithClubByIdAsync(int id)
        {
            return SporjoyDbContext.Clubs
                .Include(a => a.Id)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<Club> GetClubByMailAsync(string mail)
        {
            return SporjoyDbContext.Clubs.SingleOrDefaultAsync(a => a.Email == mail);
        }

        public Task<Club> GetCommentByIdAsync(int id)
        {
            return SporjoyDbContext.Clubs
                .Include(a => a.Comments)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public List<Branchs> GetBranchsAsync()
        {
            return  SporjoyDbContext.Branchs.ToListAsync().Result.FindAll(x => x.Id != null);
            
        }

        public List<City> GetCitiesAsync()
        {
            return SporjoyDbContext.Cities.ToListAsync().Result.FindAll(x => x.Id != null);
        }

        public List<County> GetCountiesAsync()
        {
            return SporjoyDbContext.Counties.ToListAsync().Result.FindAll(x => x.Id != null);
        }

        public async Task AddBranchCityAndCountyAsync(Branchs branch, City city, County county)
        {
            SporjoyDbContext.Branchs.Add(branch);
            SporjoyDbContext.Cities.Add(city);
            SporjoyDbContext.Counties.Add(county);
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            SporjoyDbContext.Comments.Add(comment);
        }

        public async Task UpdateAsync(Club club)
        {
            SporjoyDbContext.Clubs.Update(club);
        }

        public List<Club> GetClubByFiltersAsync(Club club) // Task<Club>
        {
            return SporjoyDbContext.Clubs.ToListAsync().Result.FindAll(x => (string.IsNullOrEmpty(club.ClubName) || x.ClubName == club.ClubName) && (string.IsNullOrEmpty(club.City) || x.City == club.City) && (string.IsNullOrEmpty(club.County) || x.County == club.County) && (club.haveParking || x.haveParking == club.haveParking) && (!club.havePrivateLesson || x.havePrivateLesson == club.havePrivateLesson) && (!club.haveShower || x.haveShower == club.haveShower) && (!club.isAvailableForDisabled || x.isAvailableForDisabled == club.isAvailableForDisabled) && x.PeymentType == club.PeymentType && x.MembershipType == club.MembershipType && (string.IsNullOrEmpty(club.Branch) || x.Branch == club.Branch));

            

            //return SporjoyDbContext.Clubs
            //    .SingleOrDefaultAsync(x => x.ClubName == club.ClubName || x.City == club.City || x.haveParking == club.haveParking || x.havePrivateLesson == club.havePrivateLesson || x.haveShower == club.haveShower || x.isAvailableForDisabled == club.isAvailableForDisabled || x.PeymentType == club.PeymentType || x.MembershipType == club.MembershipType || x.Branch == club.Branch);
        }

        private SporjoyDbContext SporjoyDbContext
        {
            get { return Context as SporjoyDbContext; }
        }
    }
}
