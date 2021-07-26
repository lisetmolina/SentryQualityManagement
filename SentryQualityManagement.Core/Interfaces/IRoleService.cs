using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IRoleService
    {
        PagedList<Roles> GetRoles(RoleQueryFilter filters);

        Task<Roles> GetRole(int id);

        Task InsertRole(Roles Role);

        Task<bool> UpdateRole(Roles role);

        Task<bool> DeleteRole(int Id);
    }
}