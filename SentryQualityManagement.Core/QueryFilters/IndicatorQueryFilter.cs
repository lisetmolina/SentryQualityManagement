using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.QueryFilters
{
    public class IndicatorQueryFilter
    {
        public string IndicatorName { get; set; }
        public string IndicatorDescription { get; set; }
        public string Formula { get; set; }
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
        
        public object AreaName { get; internal set; }
    }
}
