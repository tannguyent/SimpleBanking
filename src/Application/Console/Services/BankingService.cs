using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SimpleBankingApp.Models;
using SimpleBankingApp.Ultis;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBankingApp.Services
{
    public class BankingService : IBankingService
    {
        private readonly ApplicationSettings _applicationSettings;
        private readonly HttpClient _httpClient;
        private readonly IServiceProvider _serviceProvider;

        public BankingService(
            HttpClient httpClient,
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _applicationSettings = (serviceProvider.GetService(typeof(IOptions<ApplicationSettings>)) as IOptions<ApplicationSettings>).Value;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_applicationSettings.BankingApi.ServerUrl);
        }

        public async Task<List<TransactionModel>> GetTransactionsAsync(Guid accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await HttpClientWithAuthorization.GetAsync($"/api/transactions?accountId={accountId}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.DeserilizeResponseAsync<List<TransactionModel>>();
        }

        public async Task<BankingAccountModel> CreateDebitAccountAsync(Guid userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var content = new StringContent(JsonConvert.SerializeObject(new CreateAccountRequestModel(userId)), Encoding.UTF8, "application/json");
            var response = await HttpClientWithAuthorization.PostAsync("/api/accounts", content, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.DeserilizeResponseAsync<BankingAccountModel>();
        }

        public async Task<BankingAccountModel> GetBankingAccountAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await HttpClientWithAuthorization.GetAsync("/api/accounts/" + id, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.DeserilizeResponseAsync<BankingAccountModel>();
        }

        public async Task<BankingAccountModel> GetBankingAccountByUserIdAsync(Guid userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await HttpClientWithAuthorization.GetAsync("/api/accounts/user/" + userId, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.DeserilizeResponseAsync<BankingAccountModel>();
        }

        public async Task RecordDepositTransactionAsync(RequestCreateTransactionModel request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await HttpClientWithAuthorization.PostAsync("/api/transactions/deposit", content, cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        public async Task RecordWithdrawTransactionAsync(RequestCreateTransactionModel request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await HttpClientWithAuthorization.PostAsync("/api/transactions/withdraw", content, cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        private HttpClient HttpClientWithAuthorization
        {
            get
            {
                var context = (_serviceProvider.GetService(typeof(ApplicationContext)) as ApplicationContext);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.UserInfo.AccessToken);
                return _httpClient;
            }
        }
    }
}
