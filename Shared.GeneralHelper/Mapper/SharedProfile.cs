using AutoMapper;
using Shared.Core.Entities;
using Shared.GeneralHelper.ViewModels.Employee;
using Shared.GeneralHelper.ViewModels.NotificationViewModel;
using Shared.GeneralHelper.ViewModels.SystemLookupsVw;
using Shared.GeneralHelper.ViewModels.Users;

namespace Shared.GeneralHelper.Mapper
{
    public class SharedProfile : Profile
    {
        public SharedProfile()
        {
            CreateMap<EmpMaster, EmployeeVm>().ReverseMap();
            CreateMap<User, AppUserViewModel>().ReverseMap();
            CreateMap<User, DisplayUserViewModel>().ReverseMap();
            CreateMap<Lookups, LookupVw>().ReverseMap();
            CreateMap<LookupTypes, LookupTypeVw>().ReverseMap();
            CreateMap<Notification, NotificationVw>().ReverseMap();
        }
    }
}
