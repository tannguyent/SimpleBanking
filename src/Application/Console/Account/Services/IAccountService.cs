using System.Threading;
using System.Threading.Tasks;
using SimpleBankingApp.Account.Commands;

namespace SimpleBankingApp.Account.Services
{
    public interface IAccountService
    {
        Task<bool> CreateAccountAsync(CreateAccountCommand command, CancellationToken token = default(CancellationToken));

        Task<string> LoginAsync(LoginCommand command, CancellationToken token = default(CancellationToken));

        Task<bool> LogoutAsync(LoginCommand command, CancellationToken token = default(CancellationToken));
    }
}