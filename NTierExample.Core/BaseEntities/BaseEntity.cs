
namespace NTierExample.Core.BaseEntities
{
    public abstract class BaseEntity : IDefaultBaseEntity
    {
        public int Id { get; set; }

        public string CreatedBy { get ; set ; }

        public DateTime CreatedDate { get ; set ; }
        
        public string? UpdatedBy { get ; set ; }
        
        public DateTime? UpdatedDate { get ; set ; }
    }
}
