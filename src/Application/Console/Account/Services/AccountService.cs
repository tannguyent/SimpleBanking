using System.Threading;
using System.Threading.Tasks;
using SimpleBankingApp.Account.Commands;

namespace SimpleBankingApp.Account.Services
{
    public class AccountService : IAccountService
    {
        public Task<bool> CreateAccountAsync(CreateAccountCommand command, CancellationToken token = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public Task<string> LoginAsync(LoginCommand command, CancellationToken token = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> LogoutAsync(LoginCommand command, CancellationToken token = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}