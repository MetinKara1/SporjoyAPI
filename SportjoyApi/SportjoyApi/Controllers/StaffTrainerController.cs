﻿using Api.DTO;
using AutoMapper;
using Core;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sporjoy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class StaffTrainerController : BaseAPIController
    {
        private readonly IStaffTrainerService _staffTrainerService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        readonly IConfiguration _configuration;

        public StaffTrainerController(IStaffTrainerService staffTrainerService, IEmailService emailService, IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this._staffTrainerService = staffTrainerService;
            this._emailService = emailService;
            this._mapper = mapper;
            this._configuration = configuration;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public async Task<ActionResult<IEnumerable<StaffTrainerDTO>>> CreateStaffTrainer(StaffTrainer staffTrainer)
        {
            var createStaffTrainer = await _staffTrainerService.CreateStaffTrainer(staffTrainer);

            return Ok(createStaffTrainer);
        }

        //[HttpPost("forgot-password")]
        //public async Task<ActionResult<Club>> ForgotPassword([FromBody] User user)
        //{
        //    var userExist = await _clubService.ForgotPassword(user);
        //    if (userExist != null)
        //    {
        //        _emailService.Send("info@sporjoy.com", "n.metinkara@gmail.com", "Şifre Değiştirme İşlemi    ", "");
        //    }
        //    return Ok(user);
        //}

        //[Authorize]
        //[HttpPost("change-password")]
        //public async Task<ActionResult<Player>> ChangePassword(int userId, string password)
        //{
        //    var updatedUser = await _userService.GetUserById(userId);
        //    updatedUser.Password = password;
        //    await _userService.UpdateUser(updatedUser);
        //    return Ok(password);
        //}

        [Authorize]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<StaffTrainerDTO>>> GetAllStaffTrainers()
        {
            var staffTrainers = await _staffTrainerService.GetAllStaffTrainers();
            var staffTrainerResources = _mapper.Map<IEnumerable<StaffTrainer>, IEnumerable<StaffTrainerDTO>>(staffTrainers);

            return Ok(staffTrainerResources);
        }
    }
}
