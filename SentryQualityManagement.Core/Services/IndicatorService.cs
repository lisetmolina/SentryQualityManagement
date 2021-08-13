using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class IndicatorService : IIndicatorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public IndicatorService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Indicators> GetIndicator(int id)
        {
            return await _unitOfWork.IndicatorRepository.GetById(id);
        }
        public PagedList<Indicators> GetIndicators(IndicatorQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var indicators = _unitOfWork.IndicatorRepository.GetAll();



            if (filters.IndicatorName != null)
            {
                indicators = indicators.Where(x => x.IndicatorName == filters.IndicatorName);
            }


            var pagedIndicators = PagedList<Indicators>.Create(indicators, filters.PageNumber, filters.PageSize);
            return pagedIndicators;

        }


        public async Task<bool> UpdateIndicator(Indicators indicator)
        {
            _unitOfWork.IndicatorRepository.Update(indicator);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIndicator(int id)
        {
            await _unitOfWork.IndicatorRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task InsertIndicator(Indicators Indicator)
        {
            await _unitOfWork.IndicatorRepository.Add(Indicator);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
