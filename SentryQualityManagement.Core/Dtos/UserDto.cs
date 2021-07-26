using SentryQualityManagement.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.Dtos
{
    public class UserDto
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public bool? Active { get; set; }
        public RoleType? RoleId { get; set; }

    }
}
