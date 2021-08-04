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
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorTemplateController : ControllerBase
    {
        private readonly IIndicatorTemplateService _indicatorTemplateService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public IndicatorTemplateController(IIndicatorTemplateService indicatorTemplateService, IMapper mapper, IUriService uriService)
        {
            _indicatorTemplateService = indicatorTemplateService;
            _mapper = mapper;
            _uriService = uriService;
        }
        [HttpGet(Name = nameof(GetIndicatorsTemplate))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<IndicatorTemplateDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetIndicatorsTemplate([FromQuery] IndicatorTemplateQueryFilter filters)
        {
            var indicatorsTemplate = _indicatorTemplateService.GetIndicatorsTemplate(filters);
            var indicatorsTemplateDto = _mapper.Map<IEnumerable<IndicatorTemplateDto>>(indicatorsTemplate);


            var metadata = new Metadata
            {

                TotalCount = indicatorsTemplate.TotalCount,
                PageSize = indicatorsTemplate.PageSize,
                CurrentPage = indicatorsTemplate.CurrentPage,
                TotalPages = indicatorsTemplate.TotalPages,
                HasNextPage = indicatorsTemplate.HasNextPage,
                HasPreviousPage = indicatorsTemplate.HasPreviousPage,
                NextPageUrl = _uriService.GetIndicatorTemplatePaginationUri(filters, Url.RouteUrl(nameof(GetIndicatorsTemplate))).ToString(),
                PreviousPageUrl = _uriService.GetIndicatorTemplatePaginationUri(filters, Url.RouteUrl(nameof(GetIndicatorsTemplate))).ToString()
            };

            var response = new ApiResponse<IEnumerable<IndicatorTemplateDto>>(indicatorsTemplateDto)
            {
                Meta = metadata
            };


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIndicatorTemplate(int id)
        {

            var indicatorTemplate = await _indicatorTemplateService.GetIndicatorTemplate(id);

            var indicatorTemplateDto = _mapper.Map<IndicatorTemplateDto>(indicatorTemplate);
            var response = new ApiResponse<IndicatorTemplateDto>(indicatorTemplateDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(IndicatorTemplateDto indicatorTemplateDto)
        {
            var indicatorTemplate = _mapper.Map<IndicatorsTemplate>(indicatorTemplateDto);

            await _indicatorTemplateService.InsertIndicatorTemplate(indicatorTemplate);

            indicatorTemplateDto = _mapper.Map<IndicatorTemplateDto>(indicatorTemplate);
            var response = new ApiResponse<IndicatorTemplateDto>(indicatorTemplateDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, IndicatorTemplateDto indicatorTemplateDto)
        {
            var indicatorTemplate = _mapper.Map<IndicatorsTemplate>(indicatorTemplateDto);

            indicatorTemplate.Id = id;

            var result = await _indicatorTemplateService.UpdateIndicatorTemplate(indicatorTemplate);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _indicatorTemplateService.DeleteIndicatorTemplate(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}