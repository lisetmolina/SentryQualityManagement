using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface ITransactionService
    {
        PagedList<Transactions> GetTransactions(TransactionQueryFilter filters);

        Task<Transactions> GetTransaction(int id);

        Task InsertTransaction(Transactions transaction);

        Task<bool> UpdateTransaction(Transactions transaction);

        Task<bool> DeleteTransaction(int Id);
    }
}