using System;

namespace Shared.Core.Entities
{
    public class AttachmentFiles 
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public long FileSize { get; set; }
        public byte[] FileContent { get; set; }
    }
}
