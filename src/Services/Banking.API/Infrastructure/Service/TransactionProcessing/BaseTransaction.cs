using System;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service.TransactionProcessing
{
    public abstract class BaseTransaction : ITransaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public abstract Task ExecuteAsync(CancellationToken cancellation = default(CancellationToken));
    }
}
