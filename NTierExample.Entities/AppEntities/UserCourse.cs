using NTierExample.Core.BaseEntities;

namespace NTierExample.Entities.AppEntities
{
    public class UserCourse : BaseEntity
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
