using Api.DTO;
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
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        readonly IConfiguration _configuration;

        public UserController (IUserService playerService, IEmailService emailService, IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this._userService = playerService;
            this._emailService = emailService;
            this._mapper = mapper;
            this._configuration = configuration;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> CreatePlayer(User user)
        {
            var createPlayer = await _userService.CreateUser(user);

            return Ok(createPlayer);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Token>> Login([FromBody] UserLogin userLogin)
        {

            var users = await _userService.GetAllUsers();

            var user = users.FirstOrDefault(x => x.Email == userLogin.Email);

            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

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
                Token token = tokenHandler.CreateAccessToken(user);

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
    }
}
