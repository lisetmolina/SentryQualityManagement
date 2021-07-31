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
        private readonly IRepository<Areas> _areaRepository;
        private readonly IRepository<Indicators> _indicatorRepository;
        private readonly IRepository<IndicatorsResults> _indicatorResultRepository;

        public UnitOfWork(SentryQualityManagementContext context)
            
        {
            _context = context;
        }
        public IRepository<Roles> RoleRepository => _roleRepository ?? new BaseRepository<Roles>(_context);

        public IRepository<Users> UserRepository => _userRepository ?? new BaseRepository<Users>(_context);

        public IRepository<Areas> AreaRepository => _areaRepository ?? new BaseRepository<Areas>(_context);

        public IRepository<Indicators> IndicatorRepository => _indicatorRepository ?? new BaseRepository<Indicators>(_context);

        public IRepository<IndicatorsResults> IndicatorResultRepository => _indicatorResultRepository ?? new BaseRepository<IndicatorsResults>(_context);

        IUserRepository IUnitOfWork.UserRepository => throw new System.NotImplementedException();



        // Implementacion sugerida por el visual, nose si esta bien,preguntar...

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

        public Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
