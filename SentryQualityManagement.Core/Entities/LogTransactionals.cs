using System;
using System.Collections.Generic;



namespace SentryQualityManagement.Core.Entities
{
    public partial class LogTransactionals
    {
        public int LogTransactionalId { get; set; }
        public DateTime LogTransactionalsDate { get; set; }
        public int LogTransactionalValue { get; set; }
        public int UserId { get; set; }
        public int TransactionModuleId { get; set; }

        public virtual TransactionsModules TransactionModule { get; set; }
        public virtual Users User { get; set; }
    }
}
