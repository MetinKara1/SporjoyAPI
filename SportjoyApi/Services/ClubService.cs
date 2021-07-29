﻿using Core;
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
            return await _unitOfWork.Clubs.GetAllAsync();
        }

        public async Task<Club> GetClubById(int id)
        {
            return await _unitOfWork.Clubs.GetByIdAsync(id);
        }

        public async Task UpdateClub(Club clubToBeUpdated)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}