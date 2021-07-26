using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.Dtos
{
    public class RoleTransactionDto
    {
        public int RoleTransactionId { get; set; }
        public int RoleId { get; set; }
        public int TransactionModuleId { get; set; }

    }
}
