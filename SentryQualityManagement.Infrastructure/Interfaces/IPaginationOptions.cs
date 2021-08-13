
namespace SentryQualityManagement.Infrastructure.Interfaces
{
    public interface IPaginationOptions
    {
        int DefaultPageSize { get; set; }

        int DefaultPageNumber { get; set; }
    }
}
