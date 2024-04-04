using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierExample.Entities.AppIdentityEntities;

namespace TierExample.DAL.Contexts.EntityTypeConfiguration
{
    public class AppUserRoleConfig : BaseEntityConfiguration<AppUserRole>
    {
        public override void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(x => new {x.RoleId, x.UserId});

            builder.HasData(
                new AppUserRole
                {
                    RoleId = 1,
                    UserId = 1,
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now,
                });

            base.Configure(builder);
        }
    }
}
