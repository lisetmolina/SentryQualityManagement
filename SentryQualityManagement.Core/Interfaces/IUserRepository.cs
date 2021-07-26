
using SentryQualityManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SentryQualityManagement.Core.Interfaces
{
    public interface IUserRepository
    {
        public interface IUserRepository : IRepository<Users>
        {
            Task<Users> GetLoginByCredentials(UserLogin login);

        }

        Task Add(Users user);
        Task<Users> GetLoginByCredentials(UserLogin userLogin);
    }
}