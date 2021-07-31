using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IIndicatorTemplateService
    {
        PagedList<IndicatorsTemplate> GetIndicatorsTemplate(IndicatorTemplateQueryFilter filters);
        Task<IndicatorsTemplate> GetIndicatorTemplate(int id);
        Task InsertIndicatorTemplate(IndicatorsTemplate indicatorTemplate);
        Task<bool> UpdateIndicatorTemplate(IndicatorsTemplate indicatorTemplate);
        Task<bool> DeleteIndicatorTemplate(int id);
      
        
    }
}