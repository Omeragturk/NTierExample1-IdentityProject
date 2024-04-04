using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierExample.Entities.AppIdentityEntities;

namespace TierExample.DAL.Contexts.EntityTypeConfiguration
{
    public class AppUserTokenConfig : BaseEntityConfiguration<AppUserToken>
    {
        public override void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
         
            builder.HasNoKey();

            base.Configure(builder);
        }
    }
}
