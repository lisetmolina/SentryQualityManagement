using SentryQualityManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface ITransactionModuleRepository : IRepository<TransactionsModules>
    {
        Task<IEnumerable<TransactionsModules>> GetTransactionModuleByUser(int userId);
    }
}
