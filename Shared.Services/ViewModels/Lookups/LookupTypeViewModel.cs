using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Shared.Services.ViewModels.Lookups
{
    public class LookupTypeViewModel
    {
        public LookupTypeViewModel()
        {
            Lookups = new Collection<LookupViewModel>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public LookupTypeViewModel Parent { get; set; }
        public bool Editable { get; set; }
        public int LookupsCount { get; set; }
        public ICollection<LookupViewModel> Lookups { get; set; }
        [IgnoreDataMember]
        public ICollection<LookupTypeViewModel> Children { get; set; }
    }
}
