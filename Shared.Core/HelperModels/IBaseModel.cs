using System;

namespace Shared.Core.HelperModels
{
    public interface IBaseModel
    {
        long Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime LastModifiedTime { get; set; }
        int CreatedBy { get; set; }
        int LastModifiedBy { get; set; }
        bool IsDeleted { get; set; }
     }
}
