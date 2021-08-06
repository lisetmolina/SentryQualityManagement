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

            CreateMap<Areas, AreaDto>().ReverseMap();
          
            CreateMap<Indicators, IndicatorDto>().ReverseMap();
          
            CreateMap<IndicatorsResults, IndicatorResultDto>().ReverseMap();
          
            CreateMap<Modules, ModuleDto>().ReverseMap();
          
            CreateMap<Transactions, TransactionDto>().ReverseMap();
         
            CreateMap<Periodicities, PeriodicityDto>().ReverseMap();
           
            CreateMap<IndicatorsTemplate, IndicatorTemplateDto>().ReverseMap();
                      
            CreateMap<TransactionsModules, TransactionModuleDto>().ReverseMap();
     
            CreateMap<RoleTransactions, RoleTransactionDto>().ReverseMap();
         
        }
    }
}
