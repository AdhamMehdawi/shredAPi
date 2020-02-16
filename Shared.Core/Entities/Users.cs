using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Core.Entities
{
    public partial class User
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
        public DateTime ResetTokenExDate { get; set; }
        public bool IsSuperAdmin { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdatedBy { get; set; }
    

        public virtual EmpMaster Employee { get; set; }
    }
}
