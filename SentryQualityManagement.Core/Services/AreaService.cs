using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class AreaService :IAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public AreaService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Areas> GetArea(int id)
        {
            return await _unitOfWork.AreaRepository.GetById(id);
        }
        public PagedList<Areas> GetAreas(AreaQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var areas = _unitOfWork.AreaRepository.GetAll();


          if (filters.AreaName != null)
            {
                areas = areas.Where(x => x.AreaName == filters.AreaName);
                areas = areas.Where(x => x.AreaName == (string) filters.AreaName);
            }

                        
            var pagedAreas = PagedList<Areas>.Create(areas, filters.PageNumber, filters.PageSize);
            return pagedAreas;

        }

        public async Task InsertAreas(Areas area)
        {
            await _unitOfWork.AreaRepository.Add(area);
        }

        public async Task<bool> UpdateArea(Areas area)
        {
            _unitOfWork.AreaRepository.Update(area);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteArea(int id)
        {
            await _unitOfWork.AreaRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public Task InsertArea(Areas Area)
        {
            throw new System.NotImplementedException();
        }

       
        
    }
}
