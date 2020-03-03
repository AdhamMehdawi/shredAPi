using System;
using System.Collections.Generic;
using Shared.Core.HelperModels;

namespace Shared.Core.Entities
{
    public sealed class Lookups:BaseModel
    {
        public Lookups()
        {
            HrmEmpMasterBirthCity = new HashSet<EmpMaster>();
            HrmEmpMasterBirthCountry = new HashSet<EmpMaster>();
            HrmEmpMasterBloodType = new HashSet<EmpMaster>();
            HrmEmpMasterGender = new HashSet<EmpMaster>();
            HrmEmpMasterHealthStatus = new HashSet<EmpMaster>();
            HrmEmpMasterIdType = new HashSet<EmpMaster>();
            HrmEmpMasterMartialStatus = new HashSet<EmpMaster>();
            HrmEmpMasterNickname = new HashSet<EmpMaster>();
            HrmEmpMasterReligion = new HashSet<EmpMaster>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int? ParentId { get; set; }
        public int? LookupTypeId { get; set; }
        public string Value { get; set; }
        public int? IsPrimary { get; set; }
       

        public LookupTypes LookupType { get; set; }
        public ICollection<EmpMaster> HrmEmpMasterBirthCity { get; set; }
        public ICollection<EmpMaster> HrmEmpMasterBirthCountry { get; set; }
        public ICollection<EmpMaster> HrmEmpMasterBloodType { get; set; }
        public ICollection<EmpMaster> HrmEmpMasterGender { get; set; }
        public ICollection<EmpMaster> HrmEmpMasterHealthStatus { get; set; }
        public ICollection<EmpMaster> HrmEmpMasterIdType { get; set; }
        public ICollection<EmpMaster> HrmEmpMasterMartialStatus { get; set; }
        public ICollection<EmpMaster> HrmEmpMasterNickname { get; set; }
        public ICollection<EmpMaster> HrmEmpMasterReligion { get; set; }
    }
}