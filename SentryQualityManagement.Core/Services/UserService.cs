using Microsoft.Extensions.Options;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Users> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.UserRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Users user)
        {
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public PagedList<Users> GetUsers(UserQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var users = _unitOfWork.UserRepository.GetAll();



            if (filters.UserName != null)
            {
                users = users.Where(x => x.UserName == filters.UserName);
            }


            var pagedUsers = PagedList<Users>.Create(users, filters.PageNumber, filters.PageSize);
            return pagedUsers;

        }

        public async Task InsertUser(Users user)
        {
            await _unitOfWork.UserRepository.Add(user);
        }

        public async Task<bool> UpdateUser(Users user)
        {
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


    }
}






