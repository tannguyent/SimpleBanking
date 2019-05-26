using Microsoft.Extensions.Logging;
using SimpleBankingApp.Account.Commands;
using SimpleBankingApp.Models;
using SimpleBankingApp.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IBankingService _bankingService;
        private readonly EventDelegator _eventDelegator;
        private readonly ApplicationContext _applicationContext;

        public LoginCommandHandler(
            ILogger<LoginCommandHandler> logger,
            IAccountService accountService,
            IBankingService bankingService,
            EventDelegator eventDelegator,
            ApplicationContext applicationContext)
        {
            _logger = logger;
            _accountService = accountService;
            _bankingService = bankingService;
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
            var tokenResponse = await _accountService.LoginAsync(command, cancellationToken);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(tokenResponse.AccessToken);
            var accountId = Guid.Parse(jwtSecurityToken.Subject);

            _logger.LogInformation("LOGIN SUCCESS");
            _applicationContext.UserInfo.AccessToken = tokenResponse.AccessToken;
            _applicationContext.UserInfo.RefreshToken = tokenResponse.RefreshToken;
            _applicationContext.UserInfo.UserId = accountId;

            // get banking account
            var DebitAccountModel = await _bankingService.GetDebitAccountByUserIdAsync(accountId, cancellationToken);
            if (DebitAccountModel == null)
            {
                DebitAccountModel = await _bankingService.CreateDebitAccountAsync(accountId, cancellationToken);
            }

            _applicationContext.UserInfo.DebitAccountId = DebitAccountModel.Id;
        }
    }
}
