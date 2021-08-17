using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.QueryFilters
{
    public class UserQueryFilter
    {
        public string UserName { get; set; }
        public string Email { get; set; }
       

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
