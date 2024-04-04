using Microsoft.EntityFrameworkCore;
using NTierExample.Entities.AppEntities;
using TierExample.DAL.Contexts.EntityTypeConfiguration;

namespace TierExample.DAL.Contexts.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfig())
                        .ApplyConfiguration(new UserCourseConfig())
                        .ApplyConfiguration(new UserConfig());
        }

    }
}
