using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SentryQualityManagement.Api.Responses;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Dtos;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using SentryQualityManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SentryQualityManagemenet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleTransactionController : ControllerBase
    {
    }
    namespace SentryQualityManagement.Api.Controllers
    {
        [Authorize]
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]


        public class RoleTransactionController : ControllerBase
        {
            private readonly IRoleTransactionService _roleTransactionService;
            private readonly IMapper _mapper;
            private readonly IUriService _uriService;
            public RoleTransactionController(IRoleTransactionService roleTransactionService, IMapper mapper, IUriService uriService)
            {
                _roleTransactionService = roleTransactionService;
                _mapper = mapper;
                _uriService = uriService;
            }
            [HttpGet(Name = nameof(GetRoleTransactions))]
            [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RoleTransactionDto>>))]
            [ProducesResponseType((int)HttpStatusCode.BadRequest)]
            public IActionResult GetRoleTransactions([FromQuery] RoleTransactionQueryFilter filters)
            {
                var roleTransactions = _roleTransactionService.GetRoleTransactions(filters);
                var roleTransactionsDtos = _mapper.Map<IEnumerable<RoleTransactionDto>>(roleTransactions);


                var metadata = new Metadata
                {

                    TotalCount = roleTransactions.TotalCount,
                    PageSize = roleTransactions.PageSize,
                    CurrentPage = roleTransactions.CurrentPage,
                    TotalPages = roleTransactions.TotalPages,
                    HasNextPage = roleTransactions.HasNextPage,
                    HasPreviousPage = roleTransactions.HasPreviousPage,
                    NextPageUrl = _uriService.GetRoleTransactionPaginationUri(filters, Url.RouteUrl(nameof(GetRoleTransactions))).ToString(),
                    PreviousPageUrl = _uriService.GetRoleTransactionPaginationUri(filters, Url.RouteUrl(nameof(GetRoleTransactions))).ToString()
                };

                var response = new ApiResponse<IEnumerable<RoleTransactionDto>>(roleTransactionsDtos)
                {
                    Meta = metadata
                };


                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                return Ok(response);


            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetRoleTransaction(int id)
            {

                var roleTransaction = await _roleTransactionService.GetRoleTransaction(id);

                var RoleTransactionDto = _mapper.Map<RoleTransactionDto>(roleTransaction);
                var response = new ApiResponse<RoleTransactionDto>(RoleTransactionDto);

                return Ok(response);
            }

            [HttpPost]
            public async Task<IActionResult> Post(RoleTransactionDto roleTransactionDto)
            {
                var roleTransaction = _mapper.Map<RoleTransactions>(roleTransactionDto);

                await _roleTransactionService.InsertRoleTransaction(roleTransaction);

                roleTransactionDto = _mapper.Map<RoleTransactionDto>(roleTransaction);
                var response = new ApiResponse<RoleTransactionDto>(roleTransactionDto);
                return Ok(response);
            }

            [HttpPut]
            public async Task<IActionResult> Put(int id, RoleTransactionDto roleTransactionDto)
            {
                var roleTransaction = _mapper.Map<RoleTransactions>(roleTransactionDto);
                roleTransaction.RoleId = id;

                var result = await _roleTransactionService.UpdateRoleTransaction(roleTransaction);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {

                var result = await _roleTransactionService.DeleteRoleTransaction(id);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
        }
    }
}