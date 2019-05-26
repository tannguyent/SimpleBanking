﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBankingApp.Banking.Models
{
    public class TransactionModel
    {
        public virtual Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid BankingAccountId { get; set; }

        public decimal Amount { get; set; }

        public int Status { get; set; }
    }
}
