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

      public Uri GetModulePaginationUri(ModuleQueryFilter filter, string actionUrl)
      {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
      }

        public Uri GetTransactionPaginationUri(TransactionQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
