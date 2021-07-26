using SentryQualityManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IAreaRepository : IRepository<Areas>
    {
        Task<IEnumerable<Areas>> GetAreassByUser(int userId);
    }
}
