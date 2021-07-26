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
        private readonly IRepository<Areas> _arearepository;
        private readonly IRepository<Modules> _modulerRepository;
        private readonly IRepository<Transactions> _transactionRepository;
        private readonly IRepository<Periodicities> _periodicityRepository;
        private readonly IRepository<IndicatorsTemplate> _indicatorTemplateRepository;



        public UnitOfWork(SentryQualityManagementContext context)
            
        {
            _context = context;
        }
        public IRepository<Roles> RoleRepository => _roleRepository ?? new BaseRepository<Roles>(_context);
        public IRepository<Users> UserRepository => _userRepository ?? new BaseRepository<Users>(_context);
        public IRepository<Modules> ModuleRepository => _modulerRepository ?? new BaseRepository<Modules>(_context);
        public IRepository<Transactions> TransactionRepository => _transactionRepository ?? new BaseRepository<Transactions>(_context);
        public IRepository<Periodicities> PeriodicityRepository => _periodicityRepository ?? new BaseRepository<Periodicities>(_context);
        public IRepository<IndicatorsTemplate> IndicatorTemplateRepository => _indicatorTemplateRepository ?? new BaseRepository<IndicatorsTemplate>(_context);

        public IRepository<Areas> AreaRepository => _arearepository ?? new BaseRepository<Areas>(_context);

        IUserRepository IUnitOfWork.UserRepository => throw new System.NotImplementedException();  
        
        // Implementacion sugerida por el visual, nose si esta bien prenguntar...

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
