using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EGStore.Application.Interface;
using EGStore.Application.Mapping;
using EGStore.Application.Services;
using EGStore.Domain.Entities;
using EGStore.Infrastructure.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace EGStore.Application.Modules
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModules(this IServiceCollection services)
        {
            services.AddInfrastructureModule();
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderProductService, OrderProductService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImgService, ProductImgService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IBlogImgService, BlogImgService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            return services;
        }
    }
}
