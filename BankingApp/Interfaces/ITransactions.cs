using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface ITransactions
    {
        Account Account { get; set; }
        object Transactions { get; }
        decimal Income { get; }
        decimal Expenses { get; }
    }
}
