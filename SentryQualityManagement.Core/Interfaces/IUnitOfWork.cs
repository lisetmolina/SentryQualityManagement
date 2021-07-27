using SentryQualityManagement.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Roles> RoleRepository { get; }

        IUserRepository UserRepository { get; }

        IRepository<Modules> ModuleRepository { get; }

        IRepository<Transactions> TransactionRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();

    }
}
