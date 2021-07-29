using SentryQualityManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IIndicatorResultRepository : IRepository<IndicatorsResults>
    {
        Task<IEnumerable<IndicatorsResults>> GetIndicatorResultsByUser(int userId);
    }
}
