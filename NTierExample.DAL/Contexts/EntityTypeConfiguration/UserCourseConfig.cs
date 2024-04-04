using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierExample.Entities.AppEntities;

namespace TierExample.DAL.Contexts.EntityTypeConfiguration
{
    public class UserCourseConfig : BaseEntityConfiguration<UserCourse>
    {
        public override void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.User).WithMany(x => x.UserCourses).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Course).WithMany(x => x.UserCourses).HasForeignKey(x => x.CourseId);

            base.Configure(builder);
        }
    }
}
