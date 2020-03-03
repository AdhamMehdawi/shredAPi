using System;
using Shared.Core.HelperModels;

namespace Shared.Core.Entities
{
    public  class User:BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? EmployeeId { get; set; }
        public string FullName { get; set; }
        public bool NeedResetPassword { get; set; }
        public DateTime? PassExpireDate { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExDate { get; set; }
        public bool IsSuperAdmin { get; set; }
        public virtual EmpMaster Employee { get; set; }
    }
}
