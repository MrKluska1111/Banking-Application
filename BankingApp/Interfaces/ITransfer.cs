using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface ITransfer
    {
        Account Account { get; set; }
        void transfer(string from, string into, decimal amount, string title);
    }
}
