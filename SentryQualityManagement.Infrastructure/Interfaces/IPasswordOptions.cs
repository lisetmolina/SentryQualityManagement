
namespace SentryQualityManagement.Infrastructure.Interfaces
{
    public interface IPasswordOptions
    {
        int SaltSize { get; set; }
        int KeySize { get; set; }
        int Iterations { get; set; }
    }
}
