using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.QueryFilters;
using SentryQualityManagement.Infrastructure.Interfaces;
using System;

namespace SentryQualityManagement.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetRolePaginationUri(RoleQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
            public Uri GetAreaPaginationUri(AreaQueryFilter filter, string actionUrl)
            {
                string baseUrl = $"{_baseUri}{actionUrl}";
                return new Uri(baseUrl);
            }

            public Uri GetIndicatorPaginationUri(IndicatorQueryFilter filter, string actionUrl)
            {
                string baseUrl = $"{_baseUri}{actionUrl}";
                return new Uri(baseUrl);

            }
            public Uri GetIndicatorResultPaginationUri(IndicatorResultQueryFilter filter, string actionUrl)
            {
                string baseUrl = $"{_baseUri}{actionUrl}";
                return new Uri(baseUrl);
            }
            public Uri GetTransactionModulePaginationUri(TransactionModuleQueryFilter filter, string actionUrl)
            {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
            }

          public Uri GetRoleTransactionPaginationUri(RoleTransactionQueryFilter filter, string actionUrl)
          {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
          }

        public Uri GetModulePaginationUri(ModuleQueryFilter filter, string actionUrl)
        {
            throw new NotImplementedException();
        }

        public Uri GetTransactionPaginationUri(TransactionQueryFilter filter, string actionUrl)
        {
            throw new NotImplementedException();
        }

        public Uri GetPeriodicityPaginationUri(PeriodicityQueryFilter filter, string actionUrl)
        {
            throw new NotImplementedException();
        }

        public Uri GetIndicatorTemplatePaginationUri(IndicatorTemplateQueryFilter filter, string actionUrl)
        {
            throw new NotImplementedException();
        }

        public Uri GetUserPaginationUri(UserQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}   
