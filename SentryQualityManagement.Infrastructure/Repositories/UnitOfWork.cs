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
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Modules> _modulerRepository;
        private readonly IRepository<Transactions> _transactionRepository;
        private readonly IRepository<Periodicities> _periodicityRepository;
        private readonly IRepository<IndicatorsTemplate> _indicatorTemplateRepository;
        private readonly IRepository<Areas> _areaRepository;
        private readonly IRepository<Indicators> _indicatorRepository;
        private readonly IRepository<IndicatorsResults> _indicatorResultRepository;
        private readonly IRepository<TransactionsModules> _transactionModuleReposiory;
        private readonly IRepository<RoleTransactions> _roleTransactionRepository;
        public UnitOfWork(SentryQualityManagementContext context)
            
        {
            _context = context;
        }
        public IRepository<Roles> RoleRepository => _roleRepository ?? new BaseRepository<Roles>(_context);
        public IRepository<Modules> ModuleRepository => _modulerRepository ?? new BaseRepository<Modules>(_context);
        public IRepository<Transactions> TransactionRepository => _transactionRepository ?? new BaseRepository<Transactions>(_context);
        public IRepository<Periodicities> PeriodicityRepository => _periodicityRepository ?? new BaseRepository<Periodicities>(_context);
        public IRepository<IndicatorsTemplate> IndicatorTemplateRepository => _indicatorTemplateRepository ?? new BaseRepository<IndicatorsTemplate>(_context);
        public IRepository<Areas> AreaRepository => _areaRepository ?? new BaseRepository<Areas>(_context);
        public IRepository<Indicators> IndicatorRepository => _indicatorRepository ?? new BaseRepository<Indicators>(_context);
        public IRepository<IndicatorsResults> IndicatorResultRepository => _indicatorResultRepository ?? new BaseRepository<IndicatorsResults>(_context);
        public IRepository<TransactionsModules> TransactionModuleRepository => _transactionModuleReposiory ?? new BaseRepository<TransactionsModules>(_context);
        public IRepository<RoleTransactions> RoleTransactionRepository => _roleTransactionRepository ?? new BaseRepository<RoleTransactions>(_context);

       
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);



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
