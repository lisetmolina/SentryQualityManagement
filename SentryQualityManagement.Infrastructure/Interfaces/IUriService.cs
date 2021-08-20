using SentryQualityManagement.Core.QueryFilters;
using System;

namespace SentryQualityManagement.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetRolePaginationUri(RoleQueryFilter filter, string actionUrl);
        Uri GetUserPaginationUri(UserQueryFilter filter, string actionUrl);
        Uri GetAreaPaginationUri(AreaQueryFilter filter, string actionUrl);
        Uri GetIndicatorPaginationUri(IndicatorQueryFilter filter, string actionUrl);
        Uri GetIndicatorResultPaginationUri(IndicatorResultQueryFilter filter, string actionUrl); 
        Uri GetModulePaginationUri(ModuleQueryFilter filter, string actionUrl);
        Uri GetTransactionPaginationUri(TransactionQueryFilter filter, string actionUrl);
        Uri GetPeriodicityPaginationUri(PeriodicityQueryFilter filter, string actionUrl);
        Uri GetIndicatorTemplatePaginationUri(IndicatorTemplateQueryFilter filter, string actionUrl);
        Uri GetTransactionModulePaginationUri(TransactionModuleQueryFilter filter, string actionUrl);
        Uri GetRoleTransactionPaginationUri(RoleTransactionQueryFilter filter, string actionUrl);


    }
}