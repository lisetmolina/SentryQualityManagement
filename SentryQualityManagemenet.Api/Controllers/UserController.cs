using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SentryQualityManagement.Api.Responses;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Dtos;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using SentryQualityManagement.Infrastructure;
using SentryQualityManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SentryQualityManagemenet.Api.Controllers
{
    //[Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IUriService _uriService;
        public UserController(IUserService userService, IMapper mapper, IPasswordService passwordService, IUriService uriService)
        {
            _userService = userService;
            _mapper = mapper;
            _passwordService = passwordService;
            _uriService = uriService;
        }

        [HttpGet(Name = nameof(GetUsers))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UserDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetUsers([FromQuery] UserQueryFilter filters)
        {
            var users = _userService.GetUsers(filters);
            var usersDtos = _mapper.Map<IEnumerable<UserDto>>(users);


            var metadata = new Metadata
            {

                TotalCount = users.TotalCount,
                PageSize = users.PageSize,
                CurrentPage = users.CurrentPage,
                TotalPages = users.TotalPages,
                HasNextPage = users.HasNextPage,
                HasPreviousPage = users.HasPreviousPage,
                NextPageUrl = _uriService.GetUserPaginationUri(filters, Url.RouteUrl(nameof(GetUsers))).ToString(),
                PreviousPageUrl = _uriService.GetUserPaginationUri(filters, Url.RouteUrl(nameof(GetUsers))).ToString()
            };

            var response = new ApiResponse<IEnumerable<UserDto>>(usersDtos)
            {
                Meta = metadata
            };


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);


        }



        [HttpPost]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            var user = _mapper.Map<Users>(userDto);
            var response = new ApiResponse<UserDto>(userDto);
            try
            {
                user.UserPassword = _passwordService.Hash(user.UserPassword);
                await _userService.RegisterUser(user);
                userDto = _mapper.Map<UserDto>(user);
                response = new ApiResponse<UserDto>(userDto);
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
            
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UserDto userDto)
        {
            var user = _mapper.Map<Users>(userDto);
            user.UserId = id;

            var result = await _userService.UpdateUser(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _userService.DeleteUser(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


    }
}
