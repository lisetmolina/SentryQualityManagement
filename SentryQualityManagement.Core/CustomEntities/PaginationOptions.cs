﻿using SentryQualityManagement.Core.Interfaces;

namespace SentryQualityManagement.Core.CustomEntities
{
    public class PaginationOptions: IPaginationOptions
    {
        public int DefaultPageSize { get; set; }

        public int DefaultPageNumber { get; set; }
    }
}
