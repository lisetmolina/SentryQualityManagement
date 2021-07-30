
using SentryQualityManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SentryQualityManagement.Core.Interfaces
{
   public interface IUserRepository : IRepository<Users>
   {
    Task<Users> GetLoginByCredentials(UserLogin login);

   }

    
       
    
}