using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IAreaService
    {
        PagedList<Areas> GetAreas(AreaQueryFilter filters);

        Task<Areas> GetArea(int id);

        Task InsertArea(Areas Area);

        Task<bool> UpdateArea(Areas area);

        Task<bool> DeleteArea(int Id);

    }
}
