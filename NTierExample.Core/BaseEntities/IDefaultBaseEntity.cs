namespace NTierExample.Core.BaseEntities
{
    public interface IDefaultBaseEntity
    {
        string CreatedBy {  get; set; }

        DateTime CreatedDate { get; set; }

        string? UpdatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }
    }
}
