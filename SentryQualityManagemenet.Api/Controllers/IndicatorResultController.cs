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
using System.Threading.Tasks;

namespace SentryQualityManagemenet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorResultController : ControllerBase
    {
    }
    namespace SentryQualityManagemenet.Api.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class IndicatorResultController : ControllerBase
        {
        }
    }
    namespace SentryQualityManagement.Api.Controllers
    {
        [Authorize]
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]

        public class IndicatorResultController : ControllerBase
        {
            private readonly IIndicatorResultService _indicatorResultService;
            private readonly IMapper _mapper;
            private readonly IUriService _uriService;
            public IndicatorResultController(IIndicatorResultService indicatorResultService, IMapper mapper, IUriService uriService)
            {
                _indicatorResultService = indicatorResultService;
                _mapper = mapper;
                _uriService = uriService;
            }
            [HttpGet(Name = nameof(GetIndicatorsResults))]
            [ProducesResponseType((int)System.Net.HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<IndicatorResultDto>>))]
            [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
            public IActionResult GetIndicatorsResults([FromQuery] IndicatorResultQueryFilter filters)
            {
                var indicatorsResults = _indicatorResultService.GetIndicatorResults(filters);
                var indicatorResultDtos = _mapper.Map<IEnumerable<IndicatorResultDto>>(indicatorsResults);


                var metadata = new Metadata
                {

                    TotalCount = indicatorsResults.TotalCount,
                    PageSize = indicatorsResults.PageSize,
                    CurrentPage = indicatorsResults.CurrentPage,
                    TotalPages = indicatorsResults.TotalPages,
                    HasNextPage = indicatorsResults.HasNextPage,
                    HasPreviousPage = indicatorsResults.HasPreviousPage,
                    NextPageUrl = _uriService.GetIndicatorResultPaginationUri(filters, Url.RouteUrl(nameof(GetIndicatorsResults))).ToString(),
                    PreviousPageUrl = _uriService.GetIndicatorResultPaginationUri(filters, Url.RouteUrl(nameof(GetIndicatorsResults))).ToString()
                };

                var response = new ApiResponse<IEnumerable<IndicatorResultDto>>(indicatorResultDtos)
                {
                    Meta = metadata
                };


                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                return Ok(response);


            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetIndicatorResult(int id)
            {

                var indicatorResult = await _indicatorResultService.GetIndicatorResult(id);

                var indicatorResultDto = _mapper.Map<IndicatorResultDto>(indicatorResult);
                var response = new ApiResponse<IndicatorResultDto>(indicatorResultDto);

                return Ok(response);
            }

            [HttpPost]
            public async Task<IActionResult> Post(IndicatorResultDto indicatorResultDto)
            {
                var indicatorResult = _mapper.Map<IndicatorsResults>(indicatorResultDto);

                await _indicatorResultService.InsertIndicatorResult(indicatorResult);

                indicatorResultDto = _mapper.Map<IndicatorResultDto>(indicatorResult);
                var response = new ApiResponse<IndicatorResultDto>(indicatorResultDto);
                return Ok(response);
            }

            [HttpPut]
            public async Task<IActionResult> Put(int id, IndicatorResultDto indicatorResultDto)
            {
                var indicatorResult = _mapper.Map<IndicatorsResults>(indicatorResultDto);
                indicatorResult.Id = id;

                var result = await _indicatorResultService.UpdateIndicatorResult(indicatorResult);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {

                var result = await _indicatorResultService.DeleteIndicatorResult(id);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
        }
    }
}