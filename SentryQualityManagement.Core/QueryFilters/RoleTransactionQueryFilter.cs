using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.QueryFilters
{
    public class RoleTransactionQueryFilter
    {
        public int RoleTransactionId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
