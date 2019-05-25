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
    public class LoginCommandHandler : ICommandAsyncHandler<LoginCommand>
    {
        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly IAccountService _accountService;
        private readonly EventDelegator _eventDelegator;
        private readonly ApplicationContext _applicationContext;

        public LoginCommandHandler(
            ILogger<LoginCommandHandler> logger,
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
        public async Task HandleAsync(LoginCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogInformation("START AUTHENTICATION ACCOUNT ....");
            var response = await _accountService.LoginAsync(command, cancellationToken);

            _logger.LogInformation("LOGIN SUCCESS");
            _applicationContext.UserInfo.AccessToken = response.AccessToken;
            _applicationContext.UserInfo.RefreshToken = response.RefreshToken;
        }
    }
}
