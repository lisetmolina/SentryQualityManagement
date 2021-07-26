using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class ModuleService : IModuleService
    {
      
            private readonly IUnitOfWork _unitOfWork;

            private readonly PaginationOptions _paginationOptions;
            public ModuleService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
            {
                _unitOfWork = unitOfWork;
                _paginationOptions = options.Value;
            }

            public async Task<Modules> GetModule(int id)
            {
                return await _unitOfWork.ModuleRepository.GetById(id);
            }
            public PagedList<Modules> GetModules(ModuleQueryFilter filters)
            {
                filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
                filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

                var modules = _unitOfWork.ModuleRepository.GetAll();



                if (filters.ModuleName != null)
                {
                    modules = modules.Where(x => x.ModuleName == filters.ModuleName);
                }


                if (filters.ModuleDescription != null)
                {
                modules = modules.Where(x => x.ModuleDescription.ToLower().Contains(filters.ModuleDescription.ToLower()));
                }

                var pagedModules = PagedList<Modules>.Create(modules, filters.PageNumber, filters.PageSize);
                return pagedModules;

            }

            public async Task InsertModule(Modules module)
            {
                await _unitOfWork.ModuleRepository.Add(module);
            }

            public async Task<bool> UpdateModule(Modules module)
            {
                _unitOfWork.ModuleRepository.Update(module);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            public async Task<bool> DeleteModule(int id)
            {
                await _unitOfWork.ModuleRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }


        }
    }

