using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using SimpleBankingApp.Account.Commands;

namespace SimpleBankingApp.Account.Services
{
    public interface IAccountService
    {
        Task<bool> CreateAccountAsync(CreateAccountCommand command, CancellationToken token = default(CancellationToken));

        Task<TokenResponse> LoginAsync(LoginCommand command, CancellationToken token = default(CancellationToken));

        Task<bool> LogoutAsync(LogoutCommand command, CancellationToken token = default(CancellationToken));
    }
}