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
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SentryQualityManagemenet.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class PeriodicityController : ControllerBase
    {
        private readonly IPeriodicityService _periodicityService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public PeriodicityController(IPeriodicityService periodicityService, IMapper mapper, IUriService uriService)
        {
            _periodicityService = periodicityService;
            _mapper = mapper;
            _uriService = uriService;
        }
        [HttpGet(Name = nameof(GetPeriodicities))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PeriodicityDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPeriodicities([FromQuery] PeriodicityQueryFilter filters)
        {
            var periodicities = _periodicityService.GetPeriodicities(filters);
            var periodicitiesDtos = _mapper.Map<IEnumerable<PeriodicityDto>>(periodicities);


            var metadata = new Metadata
            {

                TotalCount = periodicities.TotalCount,
                PageSize = periodicities.PageSize,
                CurrentPage = periodicities.CurrentPage,
                TotalPages = periodicities.TotalPages,
                HasNextPage = periodicities.HasNextPage,
                HasPreviousPage = periodicities.HasPreviousPage,
                NextPageUrl = _uriService.GetPeriodicityPaginationUri(filters, Url.RouteUrl(nameof(GetPeriodicities))).ToString(),
                PreviousPageUrl = _uriService.GetPeriodicityPaginationUri(filters, Url.RouteUrl(nameof(GetPeriodicities))).ToString()
            };

            var response = new ApiResponse<IEnumerable<PeriodicityDto>>(periodicitiesDtos)
            {
                Meta = metadata
            };


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeriodicity(int id)
        {

            var periodicity = await _periodicityService.GetPeriodicity(id);

            var periodicityDto = _mapper.Map<PeriodicityDto>(periodicity);
            var response = new ApiResponse<PeriodicityDto>(periodicityDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PeriodicityDto periodicityDto)
        {
            var periodicity = _mapper.Map<Periodicities>(periodicityDto);

            await _periodicityService.InsertPeriodicity(periodicity);

            periodicityDto = _mapper.Map<PeriodicityDto>(periodicity);
            var response = new ApiResponse<PeriodicityDto>(periodicityDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PeriodicityDto periodicityDto)
        {
            var periodicity = _mapper.Map<Periodicities>(periodicityDto);
            periodicity.Id = id;

            var result = await _periodicityService.UpdatePeriodicity(periodicity);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriodicity(int id)
        {

            var result = await _periodicityService.DeletePeriodicity(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}

