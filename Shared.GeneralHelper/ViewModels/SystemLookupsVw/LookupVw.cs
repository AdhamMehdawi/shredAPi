using Shared.Core.HelperModels;

namespace Shared.GeneralHelper.ViewModels.SystemLookupsVw
{
    public class LookupVw : BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int ParentId { get; set; }
        public int LookupTypeId { get; set; }
        //public LookupTypeVw LookupType { get; set; }
    }
}
