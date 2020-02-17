 
using System.IO;

namespace Shared.Services.ViewModels.AttachmentViewModel
{
    public class DownloadAttachmentViewModel
    {
        public MemoryStream MemoryStream { get; set; }
        public string  ContentType { get; set; }
        public string FileName { get; set; }
    }
}
