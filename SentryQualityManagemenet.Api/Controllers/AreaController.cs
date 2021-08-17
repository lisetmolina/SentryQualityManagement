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
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace SentryQualityManagement.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]


    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public AreaController(IAreaService areaService, IMapper mapper, IUriService uriService)
        {
            _areaService = areaService;
            _mapper = mapper;
            _uriService = uriService;
        }
        [HttpGet(Name = nameof(GetAreas))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AreaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAreas([FromQuery] AreaQueryFilter filters)
        {
            var areas = _areaService.GetAreas(filters);
            var areasDtos = _mapper.Map<IEnumerable<AreaDto>>(areas);


            var metadata = new Metadata
            {

                TotalCount = areas.TotalCount,
                PageSize = areas.PageSize,
                CurrentPage = areas.CurrentPage,
                TotalPages = areas.TotalPages,
                HasNextPage = areas.HasNextPage,
                HasPreviousPage = areas.HasPreviousPage,
                NextPageUrl = _uriService.GetAreaPaginationUri(filters, Url.RouteUrl(nameof(GetAreas))).ToString(),
                PreviousPageUrl = _uriService.GetAreaPaginationUri(filters, Url.RouteUrl(nameof(GetAreas))).ToString()
            };

            var response = new ApiResponse<IEnumerable<AreaDto>>(areasDtos)
            {
                Meta = metadata
            };


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArea(int id)
        {

            var area = await _areaService.GetArea(id);

            var areaDto = _mapper.Map<AreaDto>(area);
            var response = new ApiResponse<AreaDto>(areaDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AreaDto areaDto)
        {
            var area = _mapper.Map<Areas>(areaDto);

            await _areaService.InsertArea(area);

            areaDto = _mapper.Map<AreaDto>(area);
            var response = new ApiResponse<AreaDto>(areaDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, AreaDto areaDto)
        {
            var area = _mapper.Map<Areas>(areaDto);
            area.AreaId = id;

            var result = await _areaService.UpdateArea(area);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _areaService.DeleteArea(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}