﻿using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.QueryFilters;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface ITransactionModuleService
    {
        PagedList<TransactionsModules> GetTransactionsModules(TransactionModuleQueryFilter filters);

        Task<TransactionsModules> GetTransactionModule(int id);

        Task InsertTransactionModule(TransactionsModules TrasactionModule);

        Task<bool> UpdateTransactionModule(TransactionsModules trasactionModule);

        Task<bool> DeleteTransactionModule(int Id);
    }
}
