using System;
using System.Collections.Generic;

namespace SentryQualityManagement.Core.Entities
{
    public partial class IndicatorsTemplate : BaseEntity
    {
        public IndicatorsTemplate()
        {
            Indicators = new HashSet<Indicators>();
        }


        public int IndicatorTemplateId { get; set; }
        public string ElementName { get; set; }
        public int ElementValue { get; set; }
        public DateTime ElementDate { get; set; }

        public virtual ICollection<Indicators> Indicators { get; set; }
    }
}
