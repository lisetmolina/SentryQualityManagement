using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IIndicatorService
    {
        PagedList<Indicators> GetIndicators(IndicatorQueryFilter filters);

        Task<Indicators> GetIndicator(int id);

        Task InsertIndicator(Indicators indicator);

        Task<bool> UpdateIndicator(Indicators indicator);

        Task<bool> DeleteIndicator(int Id);
    }
}
