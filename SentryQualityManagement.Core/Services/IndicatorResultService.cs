using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class IndicatorResultService : IIndicatorResultService
    {
   
      
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public IndicatorResultService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<IndicatorsResults> GetIndicatorsResults(int id)
        {
            return await _unitOfWork.IndicatorResultRepository.GetById(id);
        }
        public PagedList<IndicatorsResults> GetIndicatorsResults(IndicatorResultQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var indicatorsResults = _unitOfWork.IndicatorResultRepository.GetAll();


             
           

            if (filters.IndicatorResultDate != null)
            {
                indicatorsResults = indicatorsResults.Where(x => x.IndicatorResultDate == filters.IndicatorResultDate);
            }


            var pagedIndicatorsResults = PagedList<IndicatorsResults>.Create(indicatorsResults, filters.PageNumber, filters.PageSize);
            return pagedIndicatorsResults;

        }

        public async Task InsertIndicatorsResults(IndicatorsResults indicatorResult)
        {
            await _unitOfWork.IndicatorResultRepository.Add(indicatorResult);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task InsertIndicatorResults(IndicatorsResults IndicatorResult)
        {
            throw new System.NotImplementedException();
        }

        public PagedList<IndicatorsResults> GetIndicatorResults(IndicatorResultQueryFilter filters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IndicatorsResults> GetIndicatorResult(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertIndicatorResult(IndicatorsResults IndicatorResult)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateIndicatorResult(IndicatorsResults indicatorResult)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteIndicatorResult(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
