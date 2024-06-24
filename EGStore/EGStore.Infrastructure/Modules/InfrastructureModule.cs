using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Domain.Entities;
using EGStore.Domain.Repositories;
using EGStore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EGStore.Infrastructure.Modules
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {

            services.AddScoped<IDeliveryRepo, DeliveryRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderProductRepo, OrderProductRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductImgRepo, ProductImgRepo>();
            services.AddScoped<ISupplierRepo, SupplierRepo>();
            services.AddScoped<IBlogRepo, BlogRepo>();
            services.AddScoped<IBlogImgRepo, BlogImgRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            return services;
        }
    }
}
