using System;
using System.Collections.Generic;



namespace SentryQualityManagement.Core.Entities
{
    public partial class TransactionsModules
    {
        public TransactionsModules()
        {
            LogTransactionals = new HashSet<LogTransactionals>();
            RoleTransactions = new HashSet<RoleTransactions>();
        }

        public int TransactionModuleId { get; set; }
        public int TransactionId { get; set; }
        public int ModuleId { get; set; }

        public virtual Modules Module { get; set; }
        public virtual Transactions Transaction { get; set; }
        public virtual ICollection<LogTransactionals> LogTransactionals { get; set; }
        public virtual ICollection<RoleTransactions> RoleTransactions { get; set; }
    }
}
