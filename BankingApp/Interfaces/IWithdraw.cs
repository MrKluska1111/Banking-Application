using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface IWithdraw
    {
        Account Account { get; set; }
        bool withdraw(string user, decimal amount);
    }
}
