using System;

namespace Shared.Core.HelperModels
{
    public class BaseModel : IBaseModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
     
}
