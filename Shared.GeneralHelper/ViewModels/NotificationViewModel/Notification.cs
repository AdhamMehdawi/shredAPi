 
using Shared.Core.HelperModels;

namespace Shared.GeneralHelper.ViewModels.NotificationViewModel
{
    public class NotificationVw  : BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public string RedirectUrl { get; set; }
    }
}
