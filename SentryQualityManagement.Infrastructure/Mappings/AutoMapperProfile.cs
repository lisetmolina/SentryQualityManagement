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

            CreateMap<Modules, ModuleDto>();
            CreateMap<ModuleDto, Modules>();
        }
    }
}
