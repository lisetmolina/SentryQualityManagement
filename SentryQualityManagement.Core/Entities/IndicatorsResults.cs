using System;
using System.Collections.Generic;



namespace SentryQualityManagement.Core.Entities
{
    public partial class IndicatorsResults : BaseEntity
    {
        
        public int Formula { get; set; }
        public DateTime IndicatorResultDate { get; set; }
        public int Result { get; set; }
        public int PeriodicityId { get; set; }

        public virtual Periodicities Periodicity { get; set; }
    }
}
