using Application.AutoMapping;
using Application.Intrfraces;
using Application.Services;
using Domain.IRepository;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependecyInjection
{
    public static  class ServiceContainer
    {
        public static  IServiceCollection InfrastractureServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"),
            b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
            ServiceLifetime.Scoped
            );
            services.AddAutoMapper(typeof(ServiceContainer).Assembly);
            services.AddAutoMapper(typeof(Mapping));

            services.AddTransient(typeof(IBaseRepository<>) , typeof(Repository<>));
            services.AddTransient(typeof(IGenericServices<>), typeof(ServiceGN<>));
          
            return services;
        }
     
    }
}
