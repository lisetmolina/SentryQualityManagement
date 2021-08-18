using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.QueryFilters
{
    public class ModuleQueryFilter
    {
        public string ModuleName { get; set; }
        
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
