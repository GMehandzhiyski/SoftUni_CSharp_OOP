using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class Adult : Client
    {
        private const int adultInterest = 4;
        public Adult(string name, string id, double income)
            : base(name, id, adultInterest, income)
        {
        }


        public override void IncreaseInterest()
        {
            base.Interest += 2;
        }

    }
}
