using SentryQualityManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IRoleTransactionRepository
    {
        Task<IEnumerable<RoleTransactions>> GetRoleTransactionByUser(int userId);
    }
}
