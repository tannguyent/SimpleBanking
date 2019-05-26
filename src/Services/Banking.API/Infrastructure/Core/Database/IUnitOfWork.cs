using System;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Core
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}