using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SimpleBankingApp.Account.Commands;
using SimpleBankingApp.Models;

namespace SimpleBankingApp.Account.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        private readonly ApplicationSettings _applicationSettings;

        public AccountService(
            HttpClient httpClient, 
            IServiceProvider serviceProvider)
        {
            _applicationSettings = (serviceProvider.GetService(typeof(IOptions<ApplicationSettings>)) as IOptions<ApplicationSettings>).Value;
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(_applicationSettings.Identity.IdentityServer);
        }

        public async Task CreateAccountAsync(CreateAccountCommand command, CancellationToken token = default(CancellationToken))
        {
            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/Users", content, token);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await response.Content.ReadAsStringAsync());

        }

        public async Task<TokenResponse> LoginAsync(LoginCommand command, CancellationToken token = default(CancellationToken))
        {
            var disco = await GetDiscoveryIdentityServerAsync(token);
            var response = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = _applicationSettings.Identity.ClientId,
                UserName = command.UserName,
                Password = command.Password,
                Scope = _applicationSettings.Identity.Scope
            }, token);

            if (response.IsError)
            {
                throw new Exception(response.ErrorDescription);
            }

            return response;
        }

        public async Task LogoutAsync(LogoutCommand command, CancellationToken token = default(CancellationToken))
        {
            var disco = await GetDiscoveryIdentityServerAsync(token);
            var logoutResponse = await _httpClient.GetAsync($"{disco.EndSessionEndpoint}?id_token_hint={command.AccessToken}", token);
            if (logoutResponse.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await logoutResponse.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<DiscoveryResponse> GetDiscoveryIdentityServerAsync(CancellationToken token = default(CancellationToken))
        {
            var disco = await _httpClient.GetDiscoveryDocumentAsync(_applicationSettings.Identity.IdentityServer, token);
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }
            return disco;
        }

    }
}