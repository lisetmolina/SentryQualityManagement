using SentryQualityManagement.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetRolePaginationUri(RoleQueryFilter filter, string actionUrl);
    }
}