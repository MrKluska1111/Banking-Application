using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface IPayment
    {
        Account Account { get; set; }
        bool payment(string user, decimal amount);
    }
}
