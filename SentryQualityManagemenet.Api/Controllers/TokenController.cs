using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Infrastructure;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace SentryQualityManagemenet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        public TokenController(IConfiguration configuration, IUserService userService, IPasswordService passwordService)
        {
            _configuration = configuration;
            _userService = userService;
            _passwordService = passwordService;
        }

        [HttpPost]
        [Route("Authentication")]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            //if is valid user
            var validation = await IsValidUser(login);
            
            if (!validation.Item1)
            {
                return NotFound("User or password Error, please check the data entered");
            }
            var token = GenerateToken(validation.Item2);
            return Ok(new { token });

        }
        private async Task<(bool, Users)> IsValidUser(UserLogin login)
        {
            var user = await _userService.GetLoginByCredentials(login);
            var isValid = _passwordService.Check(user.UserPassword, login.Password);
            return (isValid, user);
        }

        private string GenerateToken(Users user)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            // Claims
            var claims = new []
            {
                new  Claim(ClaimTypes.Name, user.UserName),
                new  Claim(ClaimTypes.PrimarySid,$"{user.UserId}"),
                new  Claim(ClaimTypes.Role, user.Role != null? user.Role.ToString(): "0"),
                new  Claim(ClaimTypes.Email, user.Email),
            };


            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
