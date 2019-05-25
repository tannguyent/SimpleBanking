using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SimpleBankingApp.Bank.Services
{
    public class BankingService: IBankingService
    {
        private readonly HttpClient httpClient;
        private readonly IServiceProvider serviceProvider;

        public BankingService(
            HttpClient httpClient,
            IServiceProvider serviceProvider)
        {
            this.httpClient = httpClient;
            this.serviceProvider = serviceProvider;
        }
    }
}
