using System;

namespace Shared.Core.HelperModels
{
    public interface IBaseModel
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime LastModifiedTime { get; set; }
        int CreatedBy { get; set; }
        int LastModifiedBy { get; set; }
        bool IsDeleted { get; set; }
     }
}
