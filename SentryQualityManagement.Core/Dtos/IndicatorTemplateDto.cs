using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.Dtos
{
    public class IndicatorTemplateDto
    {
        public int IndicatorTemplateId { get; set; }
        public string ElementName { get; set; }
        public int ElementValue { get; set; }
        public DateTime ElementDate { get; set; }

    }
}
