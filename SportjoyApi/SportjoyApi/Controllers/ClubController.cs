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

        //[Authorize]
        [HttpPost("register")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> CreateClub([FromBody]Club club)
        {
            var clubs = await _clubService.GetAllClubs();
            var isExistPhone = clubs.Where(x => x.PhoneNumber == club.PhoneNumber);
            if (isExistPhone.ToList().Count > 0)
            {
                var response = new
                {
                    success = false,
                    phone = false
                };
                return Ok(response);
            }

            var isExistEmail = clubs.Where(x => x.Email == club.Email);
            if (isExistEmail.ToList().Count > 0)
            {
                var response = new
                {
                    success = false,
                    email = false
                };
                return Ok(response);
            }

            var photoAdd = _clubService.AddPhotos(club.Photos);

            var createClub = await _clubService.CreateClub(club);
            if (createClub.Id != 0)
            {
                var response = new
                {
                    success = true
                };
                return Ok(response);
            }


            var branch = new Branchs()
            {
                Branch = club.BranchType,
                City = club.City
            };
            var city = new City()
            {
                CityName = club.City
            };
            var county = new County()
            {
                CountyName = club.County,
                City = club.City
            };
            await _clubService.AddBranchCityAndCounty(branch, city, county);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<Token>> Login([FromBody] Club clubLogin)
        {
            var clubs = await _clubService.GetAllClubs();

            var club = clubs.FirstOrDefault(x => x.Email == clubLogin.Email && x.Password == clubLogin.Password);

            if (club != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken();

                token.UserId = club.Id;

                //Refresh token Users tablosuna işleniyor.
                club.RefreshToken = token.RefreshToken;
                club.RefreshTokenEndDate = token.Expiration.AddHours(2);
                // buraya bir userService gerekli veya CustomerService kullanıp kaydı öyle atmalıyım.
                await _unitOfWork.CommitAsync();

                return token;
            }
            return null;
        }

        [HttpGet("check-phone")]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> CheckPhone(string phone)
        {
            var clubs = await _clubService.GetAllClubs();
            var club = clubs.Where(x => x.PhoneNumber == phone);
            if (club.ToList().Count > 0)
            {
                Random generator = new Random();
                var number = generator.Next(0, 1000000).ToString("D6");
                var sms = new Entegration.Executer(phone, number);
                var result = new
                {
                    success = true,
                    number = number,
                    club = club
                };
                return Ok(result);
            }
            else
            {
                var result = new
                {
                    success = false
                };
                return Ok(result);
            }
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

        [HttpGet("branchs")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> GetBranchs()
        {
            var branchs = _clubService.GetBranchs();
            //var clubResources = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubDTO>>(clubs);
            var res = new
            {
                data = new { result = branchs }
            };
            return Ok(res);
        }

        [HttpGet("cities")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> GetCities()
        {
            var cities = _clubService.GetCities();
            //var clubResources = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubDTO>>(clubs);
            var res = new
            {
                data = new {result = cities} 
            };
            return Ok(res);
        }

        [HttpGet("counties")]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> GetCounties()
        {
            var counties = _clubService.GetCounties();
            //var clubResources = _mapper.Map<IEnumerable<Club>, IEnumerable<ClubDTO>>(clubs);
            var res = new
            {
                data = new { result = counties }
            };
            return Ok(res);
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
            var updateItem = await _clubService.GetClubById(club.Id);
            if (updateItem != null)
            {
                updateItem.BranchType = club.BranchType;
                updateItem.AgeGroups = club.AgeGroups;
                updateItem.City = club.City;
                updateItem.County = club.County;
                updateItem.MembershipType = club.MembershipType;
                updateItem.isAvailableForDisabled = club.isAvailableForDisabled;
                updateItem.havePrivateLesson = club.havePrivateLesson;
                updateItem.haveParking = club.haveParking;
                updateItem.haveShower = club.haveShower;
                await _clubService.UpdateClub(updateItem);
            }

            return Ok(updateItem);
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
