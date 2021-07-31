using SentryQualityManagement.Core.Enumerations;
using System;
using System.Collections.Generic;



namespace SentryQualityManagement.Core.Entities
{
    public partial class Roles : BaseEntity
    {
        public Roles()
        {
            RoleTransactions = new HashSet<RoleTransactions>();
            Users = new HashSet<Users>();
        }

        
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<RoleTransactions> RoleTransactions { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
