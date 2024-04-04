﻿using Microsoft.AspNetCore.Identity;
using NTierExample.Core.BaseEntities;

namespace NTierExample.Entities.AppIdentityEntities
{
    public class AppUserClaim : IdentityUserClaim<int>, IDefaultBaseEntity
    {
        public string CreatedBy { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public string? UpdatedBy { get ; set ; }
        public DateTime? UpdatedDate { get ; set ; }
    }
}
