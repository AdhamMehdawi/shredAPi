using System;
using System.Threading.Tasks;

namespace Shared.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
