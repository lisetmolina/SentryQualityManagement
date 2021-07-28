using SentryQualityManagement.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetRolePaginationUri(RoleQueryFilter filter, string actionUrl);
        Uri GetModulePaginationUri(ModuleQueryFilter filter, string actionUrl);
        Uri GetTransactionPaginationUri(TransactionQueryFilter filter, string actionUrl);
        Uri GetPeriodicityPaginationUri(PeriodicityQueryFilter filter, string actionUrl);
        Uri GetIndicatorTemplatePaginationUri(IndicatorTemplateQueryFilter filter, string actionUrl);



    }
}