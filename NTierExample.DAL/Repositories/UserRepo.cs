using NTierExample.Entities.AppEntities;
using TierExample.DAL.Base;
using TierExample.DAL.Contexts.AppContext;
using TierExample.DAL.IRepositories;

namespace TierExample.DAL.Repositories
{
    public class UserRepo : BaseRepository<User, AppDbContext>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }
    }
}
