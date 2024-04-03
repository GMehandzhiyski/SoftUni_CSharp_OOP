using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int mortgageLoanInterestRate = 3;
        private const int MortgageLoanAmount = 50_000;

        public MortgageLoan()
            : base(mortgageLoanInterestRate, MortgageLoanAmount)
        {
        }
    }
}

