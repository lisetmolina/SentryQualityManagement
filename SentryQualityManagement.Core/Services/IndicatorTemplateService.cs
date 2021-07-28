using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class IndicatorTemplateService : IIndicatorTemplateService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public IndicatorTemplateService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<IndicatorsTemplate> GetIndicatorTemplate(int id)
        {
            return await _unitOfWork.IndicatorTemplateRepository.GetById(id);
        }
        public PagedList<IndicatorsTemplate> GetIndicatorsTemplate(IndicatorTemplateQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var indicatorsTemplate = _unitOfWork.IndicatorTemplateRepository.GetAll();



            if (filters.ElementName != null)
            {
                indicatorsTemplate = indicatorsTemplate.Where(x => x.ElementName == filters.ElementName);
            }


            if (filters.ElementDate != null)
            {
                indicatorsTemplate = indicatorsTemplate.Where(x => x.ElementDate == filters.ElementDate);
            }

            var pagedIndicatorsTemplate = PagedList<IndicatorsTemplate>.Create(indicatorsTemplate, filters.PageNumber, filters.PageSize);
            return pagedIndicatorsTemplate;

        }

        public async Task InsertIndicatorTemplate(IndicatorsTemplate indicatorTemplate)
        {
            await _unitOfWork.IndicatorTemplateRepository.Add(indicatorTemplate);
        }

        public async Task<bool> UpdateIndicatorTemplate(IndicatorsTemplate indicatorTemplate)
        {
            _unitOfWork.IndicatorTemplateRepository.Update(indicatorTemplate);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIndicatorTemplate(int id)
        {
            await _unitOfWork.IndicatorTemplateRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


    }
}


