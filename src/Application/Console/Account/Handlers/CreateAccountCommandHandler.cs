using Microsoft.Extensions.Logging;
using SimpleBankingApp.Account.Commands;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;

namespace SimpleBankingApp.Account.Handlers
{
    public class CreateAccountCommandHandler : ICommandAsyncHandler<CreateAccountCommand>
    {
        private readonly ILogger<CreateAccountCommandHandler> logger;

        public CreateAccountCommandHandler(ILogger<CreateAccountCommandHandler> logger)
        {
            this.logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task HandleAsync(CreateAccountCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            logger.LogInformation("START CREATE ACCOUNT ....");
            return Task.CompletedTask;
        }
    }
}
