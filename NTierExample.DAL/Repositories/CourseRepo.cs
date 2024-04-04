using NTierExample.Entities.AppEntities;
using TierExample.DAL.Base;
using TierExample.DAL.Contexts.AppContext;
using TierExample.DAL.IRepositories;

namespace TierExample.DAL.Repositories
{
    public class CourseRepo : BaseRepository<Course, AppDbContext>, ICourseRepo
    {
        public CourseRepo(AppDbContext context) : base(context)
        {
        }
    }
}
