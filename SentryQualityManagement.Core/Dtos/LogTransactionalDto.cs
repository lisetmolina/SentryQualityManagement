using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.Dtos
{
    public class LogTransactionalDto
    {
        public int LogTransactionalId { get; set; }
        public DateTime LogTransactionalsDate { get; set; }
        public int LogTransactionalValue { get; set; }
        public int UserId { get; set; }
        public int TransactionModuleId { get; set; }
    }
}
