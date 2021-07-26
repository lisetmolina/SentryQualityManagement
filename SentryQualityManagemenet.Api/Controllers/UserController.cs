using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SentryQualityManagement.Api.Responses;
using SentryQualityManagement.Core.Dtos;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Enumerations;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Infrastructure;
using System.Threading.Tasks;

namespace SentryQualityManagemenet.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public UserController(IUserService userService, IMapper mapper, IPasswordService passwordService)
        {
            _userService = userService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            var user= _mapper.Map<Users>(userDto);

            user.UserPassword = _passwordService.Hash(user.UserPassword);
            await _userService.RegisterUser(user);

            userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }



        
    }
}