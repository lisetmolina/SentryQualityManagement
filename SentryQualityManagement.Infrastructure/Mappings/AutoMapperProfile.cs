using AutoMapper;
using SentryQualityManagement.Core.Dtos;
using SentryQualityManagement.Core.DTOs;
using SentryQualityManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Roles,RoleDto>();
            CreateMap<RoleDto,Roles>();

            CreateMap<Users, UserDto>().ReverseMap();

            CreateMap<Areas, AreaDto>();
            CreateMap<AreaDto, Areas>();

            CreateMap<Indicators, IndicatorDto>();
            CreateMap<IndicatorDto, Indicators>();

            CreateMap<Modules, ModuleDto>();
            CreateMap<ModuleDto, Modules>();

            CreateMap<Transactions, TransactionDto>();
            CreateMap<TransactionDto, Transactions>();

            CreateMap<Periodicities, PeriodicityDto>();
            CreateMap<PeriodicityDto, Periodicities>();

            CreateMap<IndicatorsTemplate, IndicatorTemplateDto>();
            CreateMap<IndicatorTemplateDto, IndicatorsTemplate>();
        }
    }
}
