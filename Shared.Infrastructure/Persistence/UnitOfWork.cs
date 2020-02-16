using System.Threading.Tasks;
using Shared.Core.Interfaces;
using Shared.Infrastructure.Data;

namespace Shared.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SharedContext _context;
        public int MyProperty { get; set; }
        public UnitOfWork(SharedContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
