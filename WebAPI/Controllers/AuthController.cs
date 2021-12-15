using Business.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        IConfiguration _configuration;
        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult CustomerRegister(CustomerRegisterDto customerRegisterDto)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult CustomerLogin(UserForLoginDto userForLoginDto)
        {
            var user = _authService.Login(userForLoginDto);
            if (!user.Success) {
                return BadRequest(user);
            }

            var tokentHandler = new TokenHandler(_configuration);
            var token = tokentHandler.CreateAccessToken(user.Data);

            user.Data.RefreshToken = token.RefreshToken;
            user.Data.RefreshTokenEndDate = (DateTime)token.Expiration.AddMinutes(3);

            return Ok(token);
            //else
        }
    }
}
