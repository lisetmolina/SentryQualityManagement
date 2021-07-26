using System;
using System.Collections.Generic;



namespace SentryQualityManagement.Core.Entities
{
    public partial class Modules : BaseEntity
    {
        public Modules()
        {
            TransactionsModules = new HashSet<TransactionsModules>();
        }

      
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }

        public virtual ICollection<TransactionsModules> TransactionsModules { get; set; }
    }
}
