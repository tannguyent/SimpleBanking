using Microsoft.Extensions.Logging;
using SimpleBankingApp.Account.Commands;
using SimpleBankingApp.Account.Services;
using SimpleBankingApp.Models;
using SimpleBankingApp.Print.Events;
using System.Threading;
using System.Threading.Tasks;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp.Account.Handlers
{
    public class LogoutCommandHandler : ICommandAsyncHandler<LogoutCommand>
    {
        private readonly ILogger<LogoutCommandHandler> _logger;
        private readonly IAccountService _accountService;
        private readonly EventDelegator _eventDelegator;
        private readonly ApplicationContext _applicationContext;

        public LogoutCommandHandler(
            ILogger<LogoutCommandHandler> logger,
            IAccountService accountService,
            EventDelegator eventDelegator,
            ApplicationContext applicationContext)
        {
            _logger = logger;
            _accountService = accountService;
            _eventDelegator = eventDelegator;
            _applicationContext = applicationContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task HandleAsync(LogoutCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogInformation("START LOGOUT ACCOUNT ....");
            var response = await _accountService.LogoutAsync(command, cancellationToken);

            _logger.LogInformation("LOGOUT SUCCESS");

            await _eventDelegator.SendAsync(new ShowHomeScreenEvent());
        }
    }
}
