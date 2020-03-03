using System;
using Shared.Core.HelperModels;

namespace Shared.Core.Entities
{
    public class AttachmentFiles:BaseModel
    {
        public new Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public long FileSize { get; set; }
         public string  FileContentData { get; set; }
    }
}
