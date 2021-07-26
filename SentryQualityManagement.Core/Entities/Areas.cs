using System;
using System.Collections.Generic;



namespace SentryQualityManagement.Core.Entities
{
    public partial class Areas
    {
        public Areas()
        {
            Indicators = new HashSet<Indicators>();
        }

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Indicators> Indicators { get; set; }
    }
}
