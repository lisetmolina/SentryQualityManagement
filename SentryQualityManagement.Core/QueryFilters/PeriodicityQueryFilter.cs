using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.QueryFilters
{
    public class PeriodicityQueryFilter
    {
        public string PeriodicityName { get; set; }
        public int PeriodicityValue { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}

