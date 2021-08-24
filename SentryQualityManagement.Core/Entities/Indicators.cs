using System;
using System.Collections.Generic;


namespace SentryQualityManagement.Core.Entities
{
    public partial class Indicators : BaseEntity
    {

        public int IndicatorId { get; set; }
        public string IndicatorName { get; set; }
        public string IndicatorDescription { get; set; }
        public string Formula { get; set; }
        public int PeriodicityId { get; set; }
        public int AreaId { get; set; }

        public virtual Areas Area { get; set; }
       
        public virtual Periodicities Periodicity { get; set; }
    }
}
