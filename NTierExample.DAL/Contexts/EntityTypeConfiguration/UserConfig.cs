using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierExample.Entities.AppEntities;
using NTierExample.Entities.AppIdentityEntities;

namespace TierExample.DAL.Contexts.EntityTypeConfiguration
{
    public class UserConfig : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            var admin = new User
            {
                Id = 1,
                Name = "admin",
                LastName = "admin",
                Email = "admin@gmail.com",
                UserName = "admin",
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
            };

            builder.HasData(admin);

            base.Configure(builder);
        }
    }
}
