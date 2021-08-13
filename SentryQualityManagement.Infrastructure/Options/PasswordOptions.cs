using SentryQualityManagement.Infrastructure.Interfaces;

namespace SentryQualityManagement.Infrastructure.Options
{
    public class PasswordOptions: IPasswordOptions
    {
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }

    }
}