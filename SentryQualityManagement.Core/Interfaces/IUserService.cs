using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<Users> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Users users);
        PagedList<Users> GetUsers(UserQueryFilter filters);
        Task InsertUser(Users user);

        Task<bool> UpdateUser(Users user);

        Task<bool> DeleteUser(int Id);
    }
}