﻿using System;

namespace Banking.API.Infrastructure.Service.Models
{
    public class RequestCreateTransactionModel
    {
        public Guid BankingAccountId { get; set; }

        public decimal Amount { get; set; }
    }
}
