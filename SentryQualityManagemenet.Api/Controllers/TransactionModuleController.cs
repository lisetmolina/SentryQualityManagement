using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SentryQualityManagement.Api.Responses;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Dtos;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using SentryQualityManagement.Core.Services;
using SentryQualityManagement.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
namespace SentryQualityManagemenet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionModuleController : ControllerBase
    {
        private readonly TransactionModuleService _transactionModuleService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public TransactionModuleController(TransactionModuleService transactionModuleService, IMapper mapper, IUriService uriService)
        {
            _transactionModuleService = transactionModuleService;
            _mapper = mapper;
            _uriService = uriService;
        }
        [HttpGet(Name = nameof(GetTransactionsModules))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TransactionModuleDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetTransactionsModules([FromQuery] TransactionModuleQueryFilter filters)
        {
            var transactionsModule = _transactionModuleService.GetTransactionsModules(filters);
            var transactionsModuleDtos = _mapper.Map<IEnumerable<TransactionModuleDto>>(transactionsModule);


            var metadata = new Metadata
            {

                TotalCount = transactionsModule.TotalCount,
                PageSize = transactionsModule.PageSize,
                CurrentPage = transactionsModule.CurrentPage,
                TotalPages = transactionsModule.TotalPages,
                HasNextPage = transactionsModule.HasNextPage,
                HasPreviousPage = transactionsModule.HasPreviousPage,
                NextPageUrl = _uriService.GetTransactionModulePaginationUri(filters, Url.RouteUrl(nameof(GetTransactionsModules))).ToString(),
                PreviousPageUrl = _uriService.GetTransactionModulePaginationUri(filters, Url.RouteUrl(nameof(GetTransactionsModules))).ToString()
            };


            var response = new ApiResponse<IEnumerable<TransactionModuleDto>>(transactionsModuleDtos)
            {
                Meta = metadata
            };


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionModule(int id)
        {

            var transactionModule = await _transactionModuleService.GetTransactionModule(id);

            var transactionModuleDto = _mapper.Map<TransactionModuleDto>(transactionModule);
            var response = new ApiResponse<TransactionModuleDto>(transactionModuleDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TransactionModuleDto transactionModuleDto)
        {
            var transactionModule = _mapper.Map<TransactionsModules>(transactionModuleDto);

            await _transactionModuleService.InsertTransactionModule(transactionModule);

            transactionModuleDto = _mapper.Map<TransactionModuleDto>(transactionModule);
            var response = new ApiResponse<TransactionModuleDto>(transactionModuleDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, TransactionModuleDto transactionModuleDto)
        {
            var transactionModule = _mapper.Map<TransactionsModules>(transactionModuleDto);
            transactionModule.Id = id;

            var result = await _transactionModuleService.UpdateTransactionModule(transactionModule);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _transactionModuleService.DeleteTransactionModule(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
