using Microsoft.AspNetCore.Mvc;
using Shared.Core.Entities;
using Shared.GeneralHelper.ViewModels.NotificationViewModel;
using Shared.Services.GenericService;

namespace Shared.API.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController :   GenericController<Notification, NotificationVw>
    {
        public NotificationController(GenericService<Notification, NotificationVw> genericService) 
            : base(genericService)
        {
        }
    }
}