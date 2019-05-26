using System;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using SimpleBankingApp.Account.Commands;

namespace SimpleBankingApp.Services
{
    public interface IAccountService
    {
        Task<Guid> CreateAccountAsync(CreateAccountCommand command, CancellationToken token = default(CancellationToken));

        Task<TokenResponse> LoginAsync(LoginCommand command, CancellationToken token = default(CancellationToken));

        Task LogoutAsync(LogoutCommand command, CancellationToken token = default(CancellationToken));
    }
}