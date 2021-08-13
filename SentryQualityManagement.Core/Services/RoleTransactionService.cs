using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class RoleTransactionService : IRoleTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public RoleTransactionService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<RoleTransactions> GetRoleTransaction(int id)
        {
            return await _unitOfWork.RoleTransactionRepository.GetById(id);
        }
        public PagedList<RoleTransactions> GetRoleTransactions(RoleTransactionQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var roleTransactions = _unitOfWork.RoleTransactionRepository.GetAll();


            if (filters.Id != 0)
            {
               roleTransactions = roleTransactions.Where(x => x.RoleId == filters.Id);
            }

            var pagedRoleTransactions = PagedList<RoleTransactions>.Create(roleTransactions, filters.PageNumber, filters.PageSize);
            return pagedRoleTransactions;

        }


        public async Task<bool> UpdateRoleTransaction(RoleTransactions roleTransaction)
        {
            _unitOfWork.RoleTransactionRepository.Update(roleTransaction);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRoleTransaction(int id)
        {
            await _unitOfWork.RoleTransactionRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task InsertRoleTransaction(RoleTransactions RoleTransaction)
        {
            await _unitOfWork.RoleTransactionRepository.Add(RoleTransaction);
            await _unitOfWork.SaveChangesAsync();
        }
    }    
}