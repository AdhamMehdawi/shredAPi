﻿namespace Shared.Core.HelperModels
{
    public class UserService
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Locale { get; set; }
        public string CurrentUrl { get; set; }
        public bool IsSuperAdmin { get; set; }
    }
}
