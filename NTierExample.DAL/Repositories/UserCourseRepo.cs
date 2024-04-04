using NTierExample.Entities.AppEntities;
using TierExample.DAL.Base;
using TierExample.DAL.Contexts.AppContext;
using TierExample.DAL.IRepositories;

namespace TierExample.DAL.Repositories
{
    public class UserCourseRepo : BaseRepository<UserCourse, AppDbContext>, IUserCourseRepo
    {
        public UserCourseRepo(AppDbContext context) : base(context)
        {
        }
    }
}
