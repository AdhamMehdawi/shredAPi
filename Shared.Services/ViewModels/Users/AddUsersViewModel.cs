using System;

namespace Shared.Services.ViewModels.Users
{
    public class RegistrationViewModel
    {
        public int? EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool NeedResetPassword { get; set; }
        public DateTime? PassExpireDate { get; set; }
    }
}
