using System;

namespace Shared.Services.ViewModels.Lookups
{
    public class LookupViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public int? ParentId { get; set; }

        public int? LookupTypeId { get; set; }
        public LookupTypeViewModel LookupType { get; set; }
        public string Value { get; set; }
        public int? IsPrimary { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}