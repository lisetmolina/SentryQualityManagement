using SentryQualityManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public  interface ITransactionRepository
    {
        public interface ITransactionRepository : IRepository<Transactions>
        {
            Task<IEnumerable<Transactions>> GetTransactionsByUser(int userId);
        }
    }
}
