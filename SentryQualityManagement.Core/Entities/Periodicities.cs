using System;
using System.Collections.Generic;


namespace SentryQualityManagement.Core.Entities
{
    public partial class Periodicities :BaseEntity
    {
        public Periodicities()
        {
            Indicators = new HashSet<Indicators>();
            IndicatorsResults = new HashSet<IndicatorsResults>();
        }

       
        public string PeriodicityName { get; set; }
        public int PeriodicityValue { get; set; }

        public virtual ICollection<Indicators> Indicators { get; set; }
        public virtual ICollection<IndicatorsResults> IndicatorsResults { get; set; }
    }
}
