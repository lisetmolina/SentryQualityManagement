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

namespace SentryQualityManagemenet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorController : ControllerBase
    {

    }
}
namespace SentryQualityManagement.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class IndicatorController : ControllerBase
        {
            private readonly IIndicatorService _indicatorService;
            private readonly IMapper _mapper;
            private readonly IUriService _uriService;
            public IndicatorController(IIndicatorService indicatorService, IMapper mapper, IUriService uriService)
            {
                _indicatorService = indicatorService;
                _mapper = mapper;
                _uriService = uriService;
            }
            [HttpGet(Name = nameof(GetIndicator))]
            [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<IndicatorDto>>))]
            [ProducesResponseType((int)HttpStatusCode.BadRequest)]
            public IActionResult GetIndicator([FromQuery] IndicatorQueryFilter filters)
            {
                var indicators = _indicatorService.GetIndicators(filters);
                var indicatorDtos = _mapper.Map<IEnumerable<IndicatorDto>>(indicators);


                var metadata = new Metadata
                {

                    TotalCount = indicators.TotalCount,
                    PageSize = indicators.PageSize,
                    CurrentPage = indicators.CurrentPage,
                    TotalPages = indicators.TotalPages,
                    HasNextPage = indicators.HasNextPage,
                    HasPreviousPage = indicators.HasPreviousPage,
                    NextPageUrl = _uriService.GetIndicatorPaginationUri(filters, Url.RouteUrl(nameof(GetIndicator))).ToString(),
                    PreviousPageUrl = _uriService.GetIndicatorPaginationUri(filters, Url.RouteUrl(nameof(GetIndicator))).ToString()
                };

                var response = new ApiResponse<IEnumerable<IndicatorDto>>(indicatorDtos)
                {
                    Meta = metadata
                };


                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                return Ok(response);


            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetIndicator(int id)
            {

                var indicator = await _indicatorService.GetIndicator(id);

                var indicatorDto = _mapper.Map<IndicatorDto>(indicator);
                var response = new ApiResponse<IndicatorDto>(indicatorDto);

                return Ok(response);
            }

            [HttpPost]
            public async Task<IActionResult> Post(IndicatorDto indicatorDto)
            {
                var indicator = _mapper.Map<Indicators>(indicatorDto);

                await _indicatorService.InsertIndicator(indicator);

                indicatorDto = _mapper.Map<IndicatorDto>(indicator);
                var response = new ApiResponse<IndicatorDto>(indicatorDto);
                return Ok(response);
            }

            [HttpPut]
            public async Task<IActionResult> Put(int id, IndicatorDto indicatorDto)
            {
                var indicator = _mapper.Map<Indicators>(indicatorDto);
                indicator.Id = id;

                var result = await _indicatorService.UpdateIndicator(indicator);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {

                var result = await _indicatorService.DeleteIndicator(id);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
        }
    }
