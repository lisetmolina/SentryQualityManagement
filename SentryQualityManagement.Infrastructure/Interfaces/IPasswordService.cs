using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure
{
    public interface IPasswordService
    {
        string Hash(string password);

        bool Check(string hash, string password);
    }
}
