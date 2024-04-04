using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTierExample.Entities.AppIdentityEntities;
using TierExample.DAL.Contexts.EntityTypeConfiguration;

namespace TierExample.DAL.Contexts.AppIdentityContext
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfig())
                   .ApplyConfiguration(new AppRoleConfig())
                   .ApplyConfiguration(new AppUserClaimConfig())
                   .ApplyConfiguration(new AppUserRoleConfig())
                   .ApplyConfiguration(new AppUserLoginConfig())
                   .ApplyConfiguration(new AppRoleClaimConfig())
                   .ApplyConfiguration(new AppUserTokenConfig());
        }
    }
}
