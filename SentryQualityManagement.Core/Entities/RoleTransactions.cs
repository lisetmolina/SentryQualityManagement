using System;
using System.Collections.Generic;



namespace SentryQualityManagement.Core.Entities
{
    public partial class RoleTransactions
    {
        public int RoleTransactionId { get; set; }
        public int RoleId { get; set; }
        public int TransactionModuleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual TransactionsModules TransactionModule { get; set; }
    }
}
