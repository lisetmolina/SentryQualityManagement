using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IPaginationOptions
    {
        int DefaultPageSize { get; set; }

        int DefaultPageNumber { get; set; }
    }
}
