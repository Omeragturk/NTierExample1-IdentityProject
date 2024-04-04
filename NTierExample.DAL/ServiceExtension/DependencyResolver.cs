using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TierExample.DAL.Contexts.AppContext;
using TierExample.DAL.Contexts.AppIdentityContext;
using TierExample.DAL.IRepositories;
using TierExample.DAL.Repositories;

namespace TierExample.DAL.ServiceExtension
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            string appDbConnection = "Server=DESKTOP-JI3UVS4; Database=Online7CourseDb;Trusted_Connection=true";
            string appIdentityConnection = "Server=DESKTOP-JI3UVS4; Database=Online7IdentityCourseDb; Trusted_Connection=true";

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(appDbConnection))
                    .AddDbContext<AppIdentityDbContext>(opt => opt.UseSqlServer(appIdentityConnection))
                    .AddScoped<IUserRepo, UserRepo>()
                    .AddScoped<ICourseRepo, CourseRepo>()
                    .AddScoped<IUserCourseRepo, UserCourseRepo>();

            return services;
        }
    }
}
