using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleBankingApp.Account.Commands;
using SimpleBankingApp.Bank.Commands;
using SimpleBankingApp.Constants;
using SimpleBankingApp.Models;
using SimpleBankingApp.Print.Events;
using Xer.Cqrs.CommandStack;
using Xer.Cqrs.EventStack;

namespace SimpleBankingApp
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly EventDelegator _eventDelegator;
        private readonly CommandDelegator _commandDelegator;
        private readonly IServiceProvider _serviceProvider;
        private readonly ApplicationSettings _config;

        public App(IOptions<ApplicationSettings> config,
                   ILogger<App> logger,
                   EventDelegator eventDelegator,
                   CommandDelegator commandDelegator,
                   IServiceProvider serviceProvider)
        {
            _logger = logger;
            _eventDelegator = eventDelegator;
            _commandDelegator = commandDelegator;
            _serviceProvider = serviceProvider;
            _config = config.Value;
        }

        public async Task Run()
        {
            do
            {
                try
                {
                    await _eventDelegator.SendAsync(new ShowHomeScreenEvent());
                    var keyCode = Console.ReadKey();
                    if (int.TryParse(keyCode.KeyChar.ToString(), out int actionNumber))
                    {
                        var action = (ActionEnum)Convert.ToInt16(actionNumber);
                        switch (action)
                        {
                            case ActionEnum.CreateAccount:
                                await _eventDelegator.SendAsync(new ShowCreateAccountScreenEvent());
                                break;
                            case ActionEnum.Login:
                                await _eventDelegator.SendAsync(new ShowLoginScreenEvent());
                                break;
                            case ActionEnum.Logout:
                                var ApplicationContext = _serviceProvider.GetService(typeof(ApplicationContext)) as ApplicationContext;
                                await _commandDelegator.SendAsync(new LogoutCommand(ApplicationContext.UserInfo.AccessToken));
                                break;
                            case ActionEnum.CreateDeposit:
                                await _eventDelegator.SendAsync(new ShowRecordDepositScreenEvent());
                                break;
                            case ActionEnum.CreateWithDraw:
                                await _eventDelegator.SendAsync(new ShowRecordWithDrawScreenEvent());
                                break;
                            case ActionEnum.CheckBalance:
                                await _commandDelegator.SendAsync(new CheckBalanceCommand());
                                break;
                            case ActionEnum.ListTransactions:
                                await _commandDelegator.SendAsync(new ListTransactionHistoryCommand());
                                break;
                            case ActionEnum.Close:
                                return;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    Console.ReadKey();
                }
            }
            while (true);
        }
    }
}
