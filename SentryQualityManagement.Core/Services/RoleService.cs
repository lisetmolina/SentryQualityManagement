using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class RoleService : IRoleService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public RoleService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Roles> GetRole(int id)
        {
            return await _unitOfWork.RoleRepository.GetById(id);
        }
        public PagedList<Roles> GetRoles(RoleQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var roles = _unitOfWork.RoleRepository.GetAll();



            if (filters.RoleName != null)
            {
                roles = roles.Where(x => x.RoleName == filters.RoleName);
            }


            if (filters.RoleDescription != null)
            {
                roles = roles.Where(x => x.RoleDescription.ToLower().Contains(filters.RoleDescription.ToLower()));
            }

            var pagedRoles = PagedList<Roles>.Create(roles, filters.PageNumber, filters.PageSize);
            return pagedRoles;

        }

          public async Task InsertRole(Roles role)
            {
                await _unitOfWork.RoleRepository.Add(role);
            }

            public async Task<bool> UpdateRole(Roles role)
            {
                _unitOfWork.RoleRepository.Update(role);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            public async Task<bool> DeleteRole(int id)
            {
                await _unitOfWork.RoleRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            return true;
            }
        

    }
}
