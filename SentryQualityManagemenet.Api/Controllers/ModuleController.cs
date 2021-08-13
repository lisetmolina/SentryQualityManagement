using Microsoft.AspNetCore.Http;
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
using SentryQualityManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SentryQualityManagemenet.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]


    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public ModuleController(IModuleService moduleService, IMapper mapper, IUriService uriService)
        {
            _moduleService = moduleService;
            _mapper = mapper;
            _uriService = uriService;
        }
        [HttpGet(Name = nameof(GetModules))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ModuleDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetModules([FromQuery] ModuleQueryFilter filters)
        {
            var modules = _moduleService.GetModules(filters);
            var modulesDtos = _mapper.Map<IEnumerable<ModuleDto>>(modules);


            var metadata = new Metadata
            {

                TotalCount = modules.TotalCount,
                PageSize = modules.PageSize,
                CurrentPage = modules.CurrentPage,
                TotalPages = modules.TotalPages,
                HasNextPage = modules.HasNextPage,
                HasPreviousPage = modules.HasPreviousPage,
                NextPageUrl = _uriService.GetModulePaginationUri(filters, Url.RouteUrl(nameof(GetModules))).ToString(),
                PreviousPageUrl = _uriService.GetModulePaginationUri(filters, Url.RouteUrl(nameof(GetModules))).ToString()
            };

            var response = new ApiResponse<IEnumerable<ModuleDto>>(modulesDtos)
            {
                Meta = metadata
            };


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModule(int id)
        {

            var module = await _moduleService.GetModule(id);

            var moduleDto = _mapper.Map<ModuleDto>(module);
            var response = new ApiResponse<ModuleDto>(moduleDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ModuleDto moduleDto)
        {
            var module = _mapper.Map<Modules>(moduleDto);

            await _moduleService.InsertModule(module);

            moduleDto = _mapper.Map<ModuleDto>(module);
            var response = new ApiResponse<ModuleDto>(moduleDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ModuleDto moduleDto)
        {
            var module = _mapper.Map<Modules>(moduleDto);
            module.ModuleId = id;

            var result = await _moduleService.UpdateModule(module);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _moduleService.DeleteModule(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}