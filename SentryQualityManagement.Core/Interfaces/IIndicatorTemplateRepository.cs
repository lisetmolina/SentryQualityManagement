using SentryQualityManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IIndicatorTemplateRepository : IRepository<IndicatorsTemplate>
    {
        Task<IEnumerable<IndicatorsTemplate>> GetRolesByUser(int userId);
    }
}