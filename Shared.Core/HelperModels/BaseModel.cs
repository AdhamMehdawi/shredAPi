using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Core.HelperModels
{
    public class BaseModel : IBaseModel
    {
        [Column("ID")]
        public virtual Guid Id { get; set; }
        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }
        [Column("LAST_MODIFIED_TIME")]
        public DateTime LastModifiedTime { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("LAST_MODIFIED_BY")]
        public int LastModifiedBy { get; set; }
        [Column("IS_DELETED")]
        public bool IsDeleted { get; set; }
    }

}
