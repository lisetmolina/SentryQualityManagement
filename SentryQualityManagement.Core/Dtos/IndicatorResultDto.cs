using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.Dtos
{
    public  class IndicatorResultDto
    {
        public int IndicatorResultId { get; set; }
        public int Formula { get; set; }
        public DateTime IndicatorResultDate { get; set; }
        public int Result { get; set; }
        public int PeriodicityId { get; set; }
    }
}
