using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class TransactionModuleService : ITransactionModuleService
    {

        private readonly IUnitOfWork _unitOfWork;
    private readonly PaginationOptions _paginationOptions;
    public TransactionModuleService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
    {
        _unitOfWork = unitOfWork;
        _paginationOptions = options.Value;
    }

    public async Task<TransactionsModules> GetTransactionModule(int id)
    {
        return await _unitOfWork.TransactionModuleRepository.GetById(id);
    }
    public PagedList<TransactionsModules> GetTransactionsModules(TransactionModuleQueryFilter filters)
    {
        filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
        filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

        var transactionsModules = _unitOfWork.TransactionModuleRepository.GetAll();



      if (filters.Id != 0) 
        {
            transactionsModules = transactionsModules.Where(x => x.Id == filters.Id);
        }

        var pagedTransactionsModules = PagedList<TransactionsModules>.Create(transactionsModules, filters.PageNumber, filters.PageSize);
        return pagedTransactionsModules;


    }

    public async Task InsertTransactionModule(TransactionsModules transactionModule)
    {
        await _unitOfWork.TransactionModuleRepository.Add(transactionModule);
    }

    public async Task<bool> UpdateTransactionModule(TransactionsModules transactionModules)
    {
        _unitOfWork.TransactionModuleRepository.Update(transactionModules);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTransactionModule(int id)
    {
        await _unitOfWork.TransactionModuleRepository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }



}
}
