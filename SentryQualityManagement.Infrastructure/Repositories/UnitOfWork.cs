using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Infrastructure.Data;
using System.Threading.Tasks;

namespace SentryQualityManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly SentryQualityManagementContext _context;
        private readonly IRepository<Roles> _roleRepository;
        private readonly IRepository<Users> _userRepository;


        public UnitOfWork(SentryQualityManagementContext context)
            
        {
            _context = context;
        }
        public IRepository<Roles> RoleRepository => _roleRepository ?? new BaseRepository<Roles>(_context);

        public IRepository<Users> UserRepository => _userRepository ?? new BaseRepository<Users>(_context);

        IUserRepository IUnitOfWork.UserRepository => throw new System.NotImplementedException();

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
