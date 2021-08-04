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
            CreateMap<Roles,RoleDto>().ReverseMap();
     
            CreateMap<Users, UserDto>().ReverseMap();

            CreateMap<Areas, AreaDto>();
            CreateMap<AreaDto, Areas>();

            CreateMap<Indicators, IndicatorDto>();
            CreateMap<IndicatorDto, Indicators>();

            CreateMap<IndicatorsResults, IndicatorResultDto>();
            CreateMap<IndicatorResultDto, IndicatorsResults>();

            CreateMap<Modules, ModuleDto>().ReverseMap();
            CreateMap<ModuleDto, Modules>().ReverseMap();

            CreateMap<Transactions, TransactionDto>().ReverseMap();
            CreateMap<TransactionDto, Transactions>().ReverseMap();

            CreateMap<Periodicities, PeriodicityDto>().ReverseMap();
            CreateMap<PeriodicityDto, Periodicities>().ReverseMap();

            CreateMap<IndicatorsTemplate, IndicatorTemplateDto>().ReverseMap();
            CreateMap<IndicatorTemplateDto, IndicatorsTemplate>().ReverseMap();

            CreateMap<Areas, AreaDto>();
            CreateMap<AreaDto, Areas>();

            CreateMap<Indicators, IndicatorDto>();
            CreateMap<IndicatorDto, Indicators>();

            CreateMap<TransactionsModules, TransactionModuleDto>();
            CreateMap<TransactionModuleDto, TransactionsModules>();

            CreateMap<RoleTransactions, RoleTransactionDto>();
            CreateMap<RoleTransactionDto, RoleTransactions>();
        }
    }
}
