using System;
using System.Collections.Generic;



namespace SentryQualityManagement.Core.Entities
{
    public partial class Transactions: BaseEntity
    {
        public Transactions()
        {
            TransactionsModules = new HashSet<TransactionsModules>();
        }

        public string TransactionName { get; set; }

        public virtual ICollection<TransactionsModules> TransactionsModules { get; set; }
    }
}
