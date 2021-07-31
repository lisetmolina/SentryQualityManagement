using SentryQualityManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Interfaces
{
    public interface IPeriodicityRepository
    {
        public interface IPeriodicityRepository : IRepository<Periodicities>
        {
            Task<IEnumerable<Periodicities>> GetPeriodicityByUser(int userId);
        }
    }
}
