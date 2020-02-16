using AutoMapper;
using Shared.Core.Entities;
using Shared.Services.ViewModels.Employee;


namespace Shared.Services.Mapper
{
    class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmpMaster, EmployeeVm>();
            
        }
    }
}
