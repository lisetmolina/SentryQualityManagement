using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.Dtos
{
    public class IndicatorDto
    {
        public int Id { get; set; }
        public string IndicatorName { get; set; }
        public string IndicatorDescription { get; set; }
        public string Formula { get; set; }
        public int PeriodicityId { get; set; }
        public int IndicatorTemplateId { get; set; }
        public int AreaId { get; set; }
    }
}
