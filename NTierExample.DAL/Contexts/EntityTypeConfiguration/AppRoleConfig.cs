using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierExample.Entities.AppIdentityEntities;

namespace TierExample.DAL.Contexts.EntityTypeConfiguration
{
    public class AppRoleConfig : BaseEntityConfiguration<AppRole>
    {
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(x => x.RoleId).IsRequired();

            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            var admin = new AppRole
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
            };

            var student = new AppRole
            {
                Id = 2,
                Name = "Student",
                NormalizedName = "Student".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
            };

            builder.HasData(admin, student);

            base.Configure(builder);
        }
    }
}
