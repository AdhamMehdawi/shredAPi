using System;
using Shared.Services.Enums;

namespace Shared.Services.ViewModels
{
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Language Language { get; set; }
    }
}
