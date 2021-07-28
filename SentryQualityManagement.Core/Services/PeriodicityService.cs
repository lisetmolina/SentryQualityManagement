using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class PeriodicityService : IPeriodicityService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public PeriodicityService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Periodicities> GetPeriodicity(int id)
        {
            return await _unitOfWork.PeriodicityRepository.GetById(id);
        }
        public PagedList<Periodicities> GetPeriodicities(PeriodicityQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var periodicities = _unitOfWork.PeriodicityRepository.GetAll();



            if (filters.PeriodicityName != null)
            {
                periodicities = periodicities.Where(x => x.PeriodicityName == filters.PeriodicityName);
            }



            var pagedPeriodicities = PagedList<Periodicities>.Create(periodicities, filters.PageNumber, filters.PageSize);
            return pagedPeriodicities;

        }

        public async Task InsertPeriodicity(Periodicities periodicity)
        {
            await _unitOfWork.PeriodicityRepository.Add(periodicity);
        }

        public async Task<bool> UpdatePeriodicity(Periodicities periodicity)
        {
            _unitOfWork.PeriodicityRepository.Update(periodicity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePeriodicity(int id)
        {
            await _unitOfWork.PeriodicityRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


    }
}
