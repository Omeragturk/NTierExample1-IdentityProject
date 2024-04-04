using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierExample.Entities.AppEntities;
using System.Runtime.CompilerServices;

namespace TierExample.DAL.Contexts.EntityTypeConfiguration
{
    public class CourseConfig : BaseEntityConfiguration<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Name).IsRequired();

            builder.HasData(
                new Course { Id = 1, Name = "C#", Description = "C# ve .Net eğitim seti", CreatedBy = "admin", CreatedDate = DateTime.Now },
                new Course { Id = 2, Name = "Java", Description = "Java eğitim seti", CreatedBy = "admin", CreatedDate = DateTime.Now },
                new Course { Id = 3, Name = "React", Description = "React eğitim seti", CreatedBy = "admin", CreatedDate = DateTime.Now }
                );

            base.Configure(builder);
        }
    }
}
