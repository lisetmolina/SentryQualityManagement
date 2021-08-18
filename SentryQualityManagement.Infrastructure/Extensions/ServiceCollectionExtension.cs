using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SentryQualityManagement.Core.CustomEntities;
using SentryQualityManagement.Core.Interfaces;
using SentryQualityManagement.Core.Services;
using SentryQualityManagement.Infrastructure.Data;
using SentryQualityManagement.Infrastructure.Interfaces;
using SentryQualityManagement.Infrastructure.Options;
using SentryQualityManagement.Infrastructure.Repositories;
using SentryQualityManagement.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SentryQualityManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SentryQualityManagementContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SentryQualityManagement"))
             );

            return services;
        }
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IEmailConfiguration>(Configuration.GetSection(NombresConstantes.NombreSeccionConfiguracionEmail).Get<EmailConfiguration>());

            services.Configure<Core.Interfaces.IPaginationOptions>(options => configuration.GetSection("Pagination").Get<PaginationOptions>());
            services.AddSingleton<IPasswordOptions>(configuration.GetSection("PasswordOptions").Get<PasswordOptions>());


            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IIndicatorService, IndicatorService>();
            services.AddTransient<IIndicatorTemplateService, IndicatorTemplateService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();
            //services.AddSingleton<IPasswordOptions, PasswordOptions>();

            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Sentry Quality Management API", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}

    

