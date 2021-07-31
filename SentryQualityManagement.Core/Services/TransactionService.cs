using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public TransactionService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Transactions> GetTransaction(int id)
        {
            return await _unitOfWork.TransactionRepository.GetById(id);
        }
        public PagedList<Transactions> GetTransactions(TransactionQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var transactions = _unitOfWork.TransactionRepository.GetAll();



            if (filters.TransactionName != null)
            {
                transactions = transactions.Where(x => x.TransactionName == filters.TransactionName);
            }

            var pagedTransactions = PagedList<Transactions>.Create(transactions, filters.PageNumber, filters.PageSize);
            return pagedTransactions;


        }

        public async Task InsertTransaction(Transactions transaction)
        {
            await _unitOfWork.TransactionRepository.Add(transaction);
        }

        public async Task<bool> UpdateTransaction(Transactions transaction)
        {
            _unitOfWork.TransactionRepository.Update(transaction);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTransaction(int id)
        {
            await _unitOfWork.TransactionRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


    }
}


