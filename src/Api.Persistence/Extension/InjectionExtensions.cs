using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Api.application.Interface;
using Api.Persistence.Context;
using Api.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Persistence.Extension
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDBContext>();
            services.AddScoped<IAnalysisRepository, AnalysisRepository>();
            
            return services;
        }
    }
}
