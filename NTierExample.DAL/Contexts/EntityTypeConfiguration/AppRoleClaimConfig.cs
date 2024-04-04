using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierExample.Entities.AppIdentityEntities;

namespace TierExample.DAL.Contexts.EntityTypeConfiguration
{
    public class AppRoleClaimConfig : BaseEntityConfiguration<AppRoleClaim>
    {
        public override void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            base.Configure(builder);
        }
    }
}
