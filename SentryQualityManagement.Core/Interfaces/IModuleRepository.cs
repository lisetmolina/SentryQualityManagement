using SentryQualityManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IModuleRepository : IRepository<Modules>
    {
        Task<IEnumerable<Modules>> GetModuleByUser(int userId);
    }
}