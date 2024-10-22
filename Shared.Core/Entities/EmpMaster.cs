﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Core.HelperModels;

namespace Shared.Core.Entities
{
    public sealed  class EmpMaster:BaseModel
    {
        public EmpMaster()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public int EmpNo { get; set; }
        public string IdNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public int? DepId { get; set; }
        public string MotherName { get; set; }
         public int IdTypeId { get; set; }
        public int GenderId { get; set; }
        public int MartialStatusId { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool ShowInReports { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {SecondName} {ThirdName} {LastName}";

        public Lookups Gender { get; set; }
        public Lookups IdType { get; set; }
        public Lookups MartialStatus { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
