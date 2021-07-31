using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IPeriodicityService
    {
        PagedList<Periodicities> GetPeriodicities(PeriodicityQueryFilter filters);
        Task<Periodicities> GetPeriodicity(int id);
        Task InsertPeriodicity(Periodicities periodicity);
        Task<bool> UpdatePeriodicity(Periodicities periodicity);
        Task<bool> DeletePeriodicity(int id);

    }
}