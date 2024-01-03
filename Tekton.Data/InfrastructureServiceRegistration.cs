using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Application.Contracts.Persistence;
using Tekton.Application.Contracts.Service;
using Tekton.Infraestructure.Persistence;
using Tekton.Infraestructure.Repositories;
using Tekton.Infraestructure.Services;

namespace Tekton.Infraestructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TektonLabsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDiscountService, DiscountService>();

            return services;
        }

    }
}
