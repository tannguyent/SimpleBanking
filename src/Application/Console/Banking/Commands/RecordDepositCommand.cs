﻿using System;

namespace SimpleBankingApp.Banking.Commands
{
    public class RecordDepositCommand
    {
        public RecordDepositCommand(Guid debitAccountId, decimal amount)
        {
            DebitAccountId = debitAccountId;
            Amount = amount;
        }

        public Guid DebitAccountId { get; }
        public decimal Amount { get; }
    }
}
