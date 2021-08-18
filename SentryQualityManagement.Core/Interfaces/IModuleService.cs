using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IModuleService
    {
        PagedList<Modules> GetModules(ModuleQueryFilter filters);

        Task<Modules> GetModule(int id);

        Task InsertModule(Modules module);

        Task<bool> UpdateModule(Modules module);

        Task<bool> DeleteModule(int Id);
    }
}