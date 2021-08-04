using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System.Threading.Tasks;


namespace SentryQualityManagement.Core.Interfaces
{
    public interface IIndicatorResultService 
    {
        PagedList<IndicatorsResults> GetIndicatorResults(IndicatorResultQueryFilter filters);

        Task<IndicatorsResults> GetIndicatorResult(int id);

        Task InsertIndicatorResult(IndicatorsResults IndicatorResult);

        Task<bool> UpdateIndicatorResult(IndicatorsResults indicatorResult);

        Task<bool> DeleteIndicatorResult(int Id);

    }
}
