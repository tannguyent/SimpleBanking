using Microsoft.Extensions.Options;
using SimpleBankingApp.Banking.Models;
using SimpleBankingApp.Models;
using SimpleBankingApp.Ultis;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBankingApp.Bank.Services
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

        public async Task<List<TransactionModel>> GetTransactionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await HttpClientWithAuthorization.GetAsync("/api/transactions", cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.DeserilizeResponseAsync<List<TransactionModel>>();
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
