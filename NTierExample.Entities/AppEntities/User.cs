using NTierExample.Core.BaseEntities;

namespace NTierExample.Entities.AppEntities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<UserCourse> UserCourses  { get; set; }

        public User()
        {
            UserCourses = new HashSet<UserCourse>();
        }
    }
}
