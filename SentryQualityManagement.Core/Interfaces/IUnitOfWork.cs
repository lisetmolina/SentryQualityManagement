﻿using SentryQualityManagement.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Roles> RoleRepository { get; }
        IUserRepository  UserRepository { get; }
        IRepository<Modules> ModuleRepository { get; }
        IRepository<Transactions> TransactionRepository { get; }
        IRepository<Periodicities> PeriodicityRepository { get; }
        IRepository<IndicatorsTemplate> IndicatorTemplateRepository { get; }
        void SaveChanges();

        Task SaveChangesAsync();

    }
}
