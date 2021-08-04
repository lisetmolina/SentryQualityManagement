using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IRoleTransactionService
    {
        PagedList<RoleTransactions> GetRoleTransactions(RoleTransactionQueryFilter filters);

        Task<RoleTransactions> GetRoleTransaction(int id);

        Task InsertRoleTransaction(RoleTransactions RoleTransaction);

        Task<bool> UpdateRoleTransaction(RoleTransactions roleTransaction);

        Task<bool> DeleteRoleTransaction(int Id);
    }
}
