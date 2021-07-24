using Api.DTO;
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
    public class CustomerController : BaseAPIController
    {
        private readonly ICustomerService _customerService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        readonly IConfiguration _configuration;

        public CustomerController (ICustomerService customerService, IEmailService emailService, IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this._customerService = customerService;
            this._emailService = emailService;
            this._mapper = mapper;
            this._configuration = configuration;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> CreateCustomer(Customer customer)
        {
            var createCustomer = await _customerService.CreateCustomer(customer);

            return Ok(createCustomer);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Token>> Login([FromForm] UserLogin userLogin)
        {
            var user = new User()
            {
                Email = "mail",
                Password = "123"
            };

            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

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
        public async Task<ActionResult<Customer>> ForgotPassword([FromBody] Customer customer)
        {
            var user = await _customerService.ForgotPassword(customer);
            if (user != null)
            {
                _emailService.Send("info@sporjoy.com", "n.metinkara@gmail.com", "Şifre değiştirme işlemi", "");
            }
            return Ok(customer);
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
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            var customerResources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);

            return Ok(customerResources);
        }
    }
}
