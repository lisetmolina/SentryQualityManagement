using Microsoft.EntityFrameworkCore;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Infrastructure.Data;
using System.Threading.Tasks;

namespace SentryQualityManagement.Infrastructure.Repositories
{
    public class UserRepository :BaseRepository<Users>, IUserRepository  
    { 
       public UserRepository(SentryQualityManagementContext context) : base(context) { }

         public async Task<Users> GetLoginByCredentials(UserLogin login)
         {
            return await _entities.FirstOrDefaultAsync(x => x.UserName == login.User);
         }
        
    }
}

