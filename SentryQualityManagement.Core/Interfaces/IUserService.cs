using SentryQualityManagement.Core.Entities;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<Users> GetLoginByCredentials(UserLogin userLogin);
    

        Task RegisterUser(Users users);
    }
}