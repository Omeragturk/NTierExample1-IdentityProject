using NTierExample.Core.BaseEntities;

namespace NTierExample.Entities.AppEntities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }

        public Course()
        {
            UserCourses = new HashSet<UserCourse>();
        }
    }
}
