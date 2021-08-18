using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SentryQualityManagement.Api.Responses;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.DTOs;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using SentryQualityManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SentryQualityManagemenet.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public RoleController(IRoleService roleService, IMapper mapper, IUriService uriService)
        {
            _roleService = roleService;
            _mapper = mapper;
            _uriService = uriService;
        }
        [HttpGet(Name = nameof(GetRoles))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RoleDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetRoles([FromQuery] RoleQueryFilter filters)
        {
            var roles = _roleService.GetRoles(filters);
            var rolesDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);
           

            var metadata = new Metadata
            {

                TotalCount = roles.TotalCount,
                PageSize = roles.PageSize,
                CurrentPage = roles.CurrentPage,
                TotalPages = roles.TotalPages,
                HasNextPage = roles.HasNextPage,
                HasPreviousPage = roles.HasPreviousPage,
                NextPageUrl = _uriService.GetRolePaginationUri(filters, Url.RouteUrl(nameof(GetRoles))).ToString(),
                PreviousPageUrl = _uriService.GetRolePaginationUri(filters, Url.RouteUrl(nameof(GetRoles))).ToString()
            };

            var response = new ApiResponse<IEnumerable<RoleDto>>(rolesDtos)
            {
                Meta = metadata
            };


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {

            var role = await _roleService.GetRole(id);

            var roleDto = _mapper.Map<RoleDto>(role);
            var response = new ApiResponse<RoleDto>(roleDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RoleDto roleDto)
        {
            var role = _mapper.Map<Roles>(roleDto);

            try
            {
                await _roleService.InsertRole(role);

                roleDto = _mapper.Map<RoleDto>(role);
                var response = new ApiResponse<RoleDto>(roleDto);
                return Ok(response);

            }
            catch(Exception ex)
            {
                return BadRequest($"Error when trying to create a new role: {ex.Message}");
            }


        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, RoleDto roleDto)
        {
            var role = _mapper.Map<Roles>(roleDto);
            role.RoleId = id;

            var result = await _roleService.UpdateRole(role);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _roleService.DeleteRole(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
