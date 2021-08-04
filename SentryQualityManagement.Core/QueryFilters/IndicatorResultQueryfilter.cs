using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.QueryFilters
{
    public class IndicatorResultQueryFilter
    {
        public int Formula { get; set; }
        public DateTime IndicatorResultDate { get; set; }
        public int Result { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
