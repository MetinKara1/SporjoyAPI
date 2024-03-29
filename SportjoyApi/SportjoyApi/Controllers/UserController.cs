﻿using Api.DTO;
using AutoMapper;
using Core;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sporjoy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class UserController : BaseAPIController
    {
        private readonly IUserService _userService;
        private readonly IClubService _clubService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        readonly IConfiguration _configuration;

        public UserController (IUserService userService, IClubService clubService, IEmailService emailService, IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this._userService = userService;
            this._clubService = clubService;
            this._emailService = emailService;
            this._mapper = mapper;
            this._configuration = configuration;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> CreatePlayer(User user)
        {
            var users = await _userService.GetAllUsers();

            var isExistPhone = users.Where(x => x.Phone == user.Phone);
            if (isExistPhone.ToList().Count > 0)
            {
                var response = new
                {
                    success = false,
                    phone = false
                };
                return Ok(response);
            }

            var isExistEmail = users.Where(x => x.Email == user.Email);
            if (isExistEmail.ToList().Count > 0)
            {
                var response = new
                {
                    success = false,
                    email = false
                };
                return Ok(response);
            }

            var createPlayer = await _userService.CreateUser(user);
            if (createPlayer.Id != 0)
            {
                var response = new
                {
                    success = true
                };
                return Ok(response);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<Token>> Login([FromBody] UserLogin userLogin)
        {
            var users = await _userService.GetAllUsers();

            var user = users.FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);

            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken();

                token.UserId = user.Id;

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddHours(2);
                // buraya bir userService gerekli veya CustomerService kullanıp kaydı öyle atmalıyım.
                await _unitOfWork.CommitAsync();

                return token;
            }
            return null;
        }

        
        [HttpGet("check-phone")]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> CheckPhone(string phone)
        {
            var users = await _userService.GetAllUsers();
            var user = users.Where(x => x.Phone == phone);
            if (user.ToList().Count > 0)
            {
                Random generator = new Random();
                var number = generator.Next(0, 1000000).ToString("D6");
                var sms = new Entegration.Executer(phone, number);
                var result = new
                {
                    success = true,
                    number = number,
                    user = user
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

        [HttpPost("forgot-password")]
        public async Task<ActionResult<Player>> ForgotPassword([FromBody] User user)
        {
            var userExist = await _userService.ForgotPassword(user);
            if (userExist != null)
            {
                _emailService.Send("info@sporjoy.com", "n.metinkara@gmail.com", "Şifre Değiştirme İşlemi    ", "");
            }
            return Ok(user);
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<ActionResult<Player>> ChangePassword(int userId, string password)
        {
            var updatedUser = await _userService.GetUserById(userId);
            updatedUser.Password = password;
            await _userService.UpdateUser(updatedUser);
            return Ok(password);
        }

        [HttpGet("[action]")]
        public async Task<Token> RefreshTokenLogin([FromForm] string refreshToken)
        {
            User user = new User() // await _context.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            {
                Email = "mail",
                Password = "123",
            };
                
            if (user != null) // && user?.RefreshTokenEndDate > DateTime.Now
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken();

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await _unitOfWork.CommitAsync();

                return token;
            }
            return null;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var playerResources = _mapper.Map<IEnumerable<User>, IEnumerable<PlayerDTO>>(users);

            return Ok(playerResources);
        }

        [Authorize]
        [HttpGet("get-user")]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            var club = new Club();
            if (user != null )
            {
                var result = new
                {
                    user = user,
                    club = club
                };
                return Ok(result);
            }
            //var playerResources = _mapper.Map<IEnumerable<User>, IEnumerable<PlayerDTO>>(users);
            //club = await _clubService.GetClubByMail(user.Email);

            club = await _clubService.GetClubById(id);
            if (club != null)
            {
                var result = new
                {
                    user = user,
                    club = club
                };

                return Ok(result);
            }
            return Ok();
        }

        [Authorize]
        [HttpPost("update-user")]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> UpdateUser(User user)
        {
            var updateItem = await _userService.GetUserById(user.Id);
            if (updateItem != null)
            {
                updateItem.Name = user.Name;
                updateItem.Surname = user.Surname;
                updateItem.Email = user.Email;
                updateItem.Phone = user.Phone;
                await _userService.UpdateUser(updateItem);
            }
            
            return Ok();
        }
    }
}
