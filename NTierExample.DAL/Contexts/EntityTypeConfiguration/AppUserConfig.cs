using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierExample.Entities.AppIdentityEntities;

namespace TierExample.DAL.Contexts.EntityTypeConfiguration
{
    public class AppUserConfig : BaseEntityConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.LastName).IsRequired();
            builder.Property(t => t.Password).IsRequired();

            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var admin = new AppUser
            {
                Id = 1,
                Name = "admin",
                LastName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Password = "admin",
                SecurityStamp = Guid.NewGuid().ToString(),
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
            };

            admin.PasswordHash = HashPassword(admin, admin.Password);

            builder.HasData(admin);

            base.Configure(builder);
        }

        private string HashPassword(AppUser appUser, string password)
        {
            var paswordHasher = new PasswordHasher<AppUser>();
            return paswordHasher.HashPassword(appUser, password);
        }
    }
}
