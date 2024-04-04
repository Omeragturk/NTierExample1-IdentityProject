using Microsoft.Extensions.DependencyInjection;
using NTierExample.BLL.IServices;
using NTierExample.BLL.Mapper;
using NTierExample.BLL.Services;

namespace NTierExample.BLL.ServiceExtension
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddAutoMapper(act => act.AddProfile<Mapping>())
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<IAdminService, AdminService>();

            return services;
        }
    }
}
