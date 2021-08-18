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
using System.Net;
using System.Threading.Tasks;

namespace SentryQualityManagemenet.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public TransactionController(ITransactionService transactionService, IMapper mapper, IUriService uriService)
        {
            _transactionService = transactionService;
            _mapper = mapper;
            _uriService = uriService;
        }
        [HttpGet(Name = nameof(GetTransactions))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TransactionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetTransactions([FromQuery] TransactionQueryFilter filters)
        {
            var transactions = _transactionService.GetTransactions(filters);
            var transactionsDtos = _mapper.Map<IEnumerable<TransactionDto>>(transactions);


            var metadata = new Metadata
            {

                TotalCount = transactions.TotalCount,
                PageSize = transactions.PageSize,
                CurrentPage = transactions.CurrentPage,
                TotalPages = transactions.TotalPages,
                HasNextPage = transactions.HasNextPage,
                HasPreviousPage = transactions.HasPreviousPage,
                NextPageUrl = _uriService.GetTransactionPaginationUri(filters, Url.RouteUrl(nameof(GetTransactions))).ToString(),
                PreviousPageUrl = _uriService.GetTransactionPaginationUri(filters, Url.RouteUrl(nameof(GetTransactions))).ToString()
            };


            var response = new ApiResponse<IEnumerable<TransactionDto>>(transactionsDtos)
            {
                Meta = metadata
            };


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {

            var transaction = await _transactionService.GetTransaction(id);

            var transactionDto = _mapper.Map<TransactionDto>(transaction);
            var response = new ApiResponse<TransactionDto>(transactionDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transactions>(transactionDto);
          
            try
            {
                await _transactionService.InsertTransaction(transaction);

                transactionDto = _mapper.Map<TransactionDto>(transaction);
                var response = new ApiResponse<TransactionDto>(transactionDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error when trying to create a new Transaction: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transactions>(transactionDto);
            transaction.TransactionId = id;

            var result = await _transactionService.UpdateTransaction(transaction);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _transactionService.DeleteTransaction(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}