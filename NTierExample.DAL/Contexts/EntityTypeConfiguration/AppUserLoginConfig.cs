using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierExample.Entities.AppIdentityEntities;

namespace TierExample.DAL.Contexts.EntityTypeConfiguration
{
    public class AppUserLoginConfig : BaseEntityConfiguration<AppUserLogin>
    {
        public override void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            builder.HasNoKey();

            base.Configure(builder);
        }
    }
}
