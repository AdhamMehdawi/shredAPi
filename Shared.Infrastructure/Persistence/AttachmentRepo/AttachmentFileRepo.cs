using Shared.Core.Entities;
using Shared.Core.Interfaces.IAttachmentRepo;
using Shared.Infrastructure.Data;

namespace Shared.Infrastructure.Persistence.AttachmentRepo
{
    public class AttachmentFileRepo : Repo<AttachmentFiles>, IAttachmentFileRepo
    {
        private readonly SharedContext _context;
        public AttachmentFileRepo(SharedContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
