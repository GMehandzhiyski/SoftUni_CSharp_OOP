using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int studentLoanInterestRate = 1;
        private const double studentLoanAmount = 10_000;

        public StudentLoan()
            : base(studentLoanInterestRate, studentLoanAmount)
        {
        }
    }
}
