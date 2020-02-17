using System;
using Shared.Services.ViewModels.Employee;

namespace Shared.Services.ViewModels.Users
{
    public class AppUserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? EmployeeId { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public string FullName { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool NeedResetPassword { get; set; }
        public DateTime? PassExpireDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}