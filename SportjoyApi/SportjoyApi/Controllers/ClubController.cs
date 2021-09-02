using Api.DTO;
using AutoMapper;
using Core;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sporjoy.Core;
using Sporjoy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class ClubController : BaseAPIController
    {
        private readonly IClubService _clubService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        readonly IConfiguration _configuration;

        public ClubController (IClubService clubService, IUserService userService, IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this._clubService = clubService;
            this._userService = userService;
            this._mapper = mapper;
            this._configuration = configuration;
            this._unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpPost("register")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> CreateClub([FromBody]Club club)
        {
            var createClub = await _clubService.CreateClub(club);

            return Ok(createClub);
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

        //[Authorize]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> GetAllClubs()
        {
            var clubs = await _clubService.GetAllClubs();
            //var clubResources = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubDTO>>(clubs);

            return Ok(clubs);
        }

        [HttpGet("clubDetail")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> GetClubDetail(int id)
        {
            var club = await _clubService.GetClubById(id);
            //var clubResources = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubDTO>>(clubs);

            return Ok(club);
        }

        [Authorize]
        [HttpPost("update-club")]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> UpdateClub(Club club)
        {
            var updateItem = await _clubService.GetClubByMail(club.Email);
            if (updateItem != null)
            {
                //updateItem.Name = user.Name;
                //updateItem.Surname = user.Surname;
                //updateItem.Email = user.Email;
                //await _userService.UpdateUser(updateItem);
            }

            return Ok();
        }

        [HttpGet("comment")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> GetCommentById(int id)
        {
            var comments = await _clubService.GetCommentsById(id);
            //var clubResources = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubDTO>>(clubs);

            return Ok(comments);
        }

        [HttpPost("comment")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> CreateComment([FromBody] Comment comment)
        {
            var user = await _userService.GetUserById(int.Parse(comment.Commenter));
            comment.Commenter = user.Name + " " + user.Surname;
            comment.CommentDate = DateTime.Now;
            await _clubService.CreateComment(comment);
            //var clubResources = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubDTO>>(clubs);

            return Ok();
        }

        [HttpPost("filters")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> GetClubByFilters([FromBody] Club club)
        {
            var filteredClubs = _clubService.GetClubByFilters(club); // await

            return Ok(filteredClubs);
        }

    }
}
