using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SimpleBankingApp.Account.Commands;

namespace SimpleBankingApp.Account.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient httpClient;

        public AccountService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
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