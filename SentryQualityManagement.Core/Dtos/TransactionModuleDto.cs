﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Core.Dtos
{
     public class TransactionModuleDto
    {
        public int TransactionModuleId { get; set; }
        public int TransactionId { get; set; }
        public int ModuleId { get; set; }
    }
}
