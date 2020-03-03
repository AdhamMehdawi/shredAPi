using System;
using System.Collections.Generic;
using Shared.Core.HelperModels;

namespace Shared.Core.Entities
{
    public sealed class LookupTypes: BaseModel
    {
        public LookupTypes()
        {
            InverseParent = new HashSet<LookupTypes>();
            Lookups = new HashSet<Lookups>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public bool Editable { get; set; }

        public LookupTypes Parent { get; set; }
        public ICollection<LookupTypes> InverseParent { get; set; }
        public ICollection<Lookups> Lookups { get; set; }
    }
}
