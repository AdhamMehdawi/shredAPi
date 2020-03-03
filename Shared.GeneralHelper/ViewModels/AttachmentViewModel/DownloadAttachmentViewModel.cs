 
using System.IO;

namespace Shared.GeneralHelper.ViewModels.AttachmentViewModel
{
    public class DownloadAttachmentViewModel
    {
        public MemoryStream MemoryStream { get; set; }
        public string  ContentType { get; set; }
        public string FileName { get; set; }
    }
}
