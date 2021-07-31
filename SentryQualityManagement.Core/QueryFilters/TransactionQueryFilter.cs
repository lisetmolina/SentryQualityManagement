namespace SentryQualityManagement.Core.QueryFilters
{
    public class TransactionQueryFilter
    {
        public string TransactionName { get; set; }
        
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
