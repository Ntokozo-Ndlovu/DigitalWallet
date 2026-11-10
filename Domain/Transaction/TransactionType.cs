using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Transaction
{
    public enum TransactionType
    {
        Deposit = 0,
        Withdrawal = 1,
        Transfer,
        Reversal
    }
}
