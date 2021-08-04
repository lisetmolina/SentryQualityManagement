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


            /*if (filters.RoleTransactionId != null)
            {
               roleTransactionId = roleTransactionId.Where(x => x.RoleTransactionId == filters.RoleTransactionId);
            }*/

            var pagedRoleTransactions = PagedList<RoleTransactions>.Create(roleTransactions, filters.PageNumber, filters.PageSize);
            return pagedRoleTransactions;

        }

        public async Task InsertRoleTransactions(RoleTransactions roleTransaction)
        {
            await _unitOfWork.RoleTransactionRepository.Add(roleTransaction);
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

        public Task InsertRoleTransaction(RoleTransactions RoleTransaction)
        {
            throw new System.NotImplementedException();
        }
    }    
}