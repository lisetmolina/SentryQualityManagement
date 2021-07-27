using SentryQualityManagement.Core.Enumerations;

namespace SentryQualityManagement.Core.DTOs
{
    public class RoleDto
    {
        public RoleType? Id { get; set; }
        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public bool Active { get; set; }

    }
}
