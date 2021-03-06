using System.Collections.Generic;



namespace SentryQualityManagement.Core.Entities
{
    public partial class Users : BaseEntity
    {
        public Users()
        {
            Areas = new HashSet<Areas>();
            LogTransactionals = new HashSet<LogTransactionals>();
        }


        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public bool? Active { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Areas> Areas { get; set; }
        public virtual ICollection<LogTransactionals> LogTransactionals { get; set; }
    }
}
