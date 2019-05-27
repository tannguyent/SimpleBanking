using System;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.API.Infrastructure.Service.TransactionProcessing
{
    public interface ITransaction
    {
        Guid Id { get; set; }
        DateTime CreatedOn { get; set; }

        Task ExecuteAsync(TransactionManager context, CancellationToken cancellation = default(CancellationToken));
    }
}
