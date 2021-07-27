using SentryQualityManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
     public interface IIndicatorRepository : IRepository<Indicators>
    {
        Task<IEnumerable<Indicators>> GetIndicatorsByUser(int userId);
    }
}

