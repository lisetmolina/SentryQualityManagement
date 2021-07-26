using SentryQualityManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IRoleRepository : IRepository<Roles>
    {
        Task<IEnumerable<Roles>> GetRolesByUser(int userId);
    }
}