using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependecies
    {
        public static IServiceCollection AddCoreDependecies(this IServiceCollection services)
        {
            //Configure MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configure AutoMapper
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
