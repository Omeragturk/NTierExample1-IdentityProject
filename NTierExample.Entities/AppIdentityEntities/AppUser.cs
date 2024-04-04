using Microsoft.AspNetCore.Identity;
using NTierExample.Core.BaseEntities;

namespace NTierExample.Entities.AppIdentityEntities
{
    public class AppUser : IdentityUser<int>, IDefaultBaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
