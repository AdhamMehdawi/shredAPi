using System;
using Shared.GeneralHelper.ViewModels.SystemLookupsVw;

namespace Shared.GeneralHelper.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public int EmpNo { get; set; }
        public string IdNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {SecondName} {ThirdName} {LastName}";
        public string MotherName { get; set; }
        public int IdTypeId { get; set; }
        public LookupVw IdType { get; set; }
        public int GenderId { get; set; }
        public LookupVw Gender { get; set; }
        public int MartialStatusId { get; set; }
        public LookupVw MartialStatus { get; set; }
        public DateTime? Birthdate { get; set; } 
        public bool ShowInReports { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}