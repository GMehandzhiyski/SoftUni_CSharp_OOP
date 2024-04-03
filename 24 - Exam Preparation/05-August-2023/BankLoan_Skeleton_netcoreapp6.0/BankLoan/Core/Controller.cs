using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        //private LoanRepository loanRepository;
        //private BankRepository bankRepository;
        private IRepository<ILoan> loanRepository;
        private IRepository<IBank> bankRepository;



        public Controller()
        {
            loanRepository = new LoanRepository();
            bankRepository = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            string result = string.Empty;

            IBank bank;

            if (bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }

            else if (bankTypeName == nameof(CentralBank))
            {
                bank = new CentralBank(name);
            }

            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.BankTypeInvalid));
            }

            bankRepository.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }
        public string AddLoan(string loanTypeName)
        {
            ILoan loan;
            if (loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }

            else if (loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }

            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.LoanTypeInvalid));
            }

            loanRepository.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }
        public string ReturnLoan(string bankName, string loanTypeName)
        {
            IBank currBank = bankRepository.FirstModel(bankName);

            if (loanRepository.FirstModel(loanTypeName) == default)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            ILoan currLoan = loanRepository.FirstModel(loanTypeName);
            currBank.AddLoan(currLoan);
            loanRepository.RemoveModel(currLoan);


            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            string result = string.Empty;

            IBank currBank = bankRepository.FirstModel(bankName);
            IClient currClient;

            if ((currBank.GetType().Name == nameof(BranchBank) && clientTypeName != nameof(Student))
                || (currBank.GetType().Name == nameof(CentralBank) && clientTypeName != nameof(Adult)))
            {
                result = string.Format(OutputMessages.UnsuitableBank);
            }
            else if (clientTypeName == nameof(Adult))
            {
                currClient = new Adult(clientName, id, income);
                currBank.AddClient(currClient);
                result = string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
            }
            else if (clientTypeName == nameof(Student))
            {
                currClient = new Student(clientName, id, income);
                currBank.AddClient(currClient);
                result = string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);

            }
            else
            {
                throw new AggregateException(string.Format(ExceptionMessages.ClientTypeInvalid));
            }

            return result;
        }


        public string FinalCalculation(string bankName)
        {
            IBank currBank = bankRepository.FirstModel(bankName);

            var sunOfIncome = currBank.Clients.Sum(c => c.Income);
            var sumOfAmount = currBank.Loans.Sum(c => c.Amount);
            var sumOfFurnds =(sunOfIncome + sumOfAmount);
            string formattedSum = sumOfFurnds.ToString("0.00");

            return string.Format(OutputMessages.BankFundsCalculated, bankName, formattedSum);
        }


        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currBank in bankRepository.Models)
            {
                sb.AppendLine(currBank.GetStatistics());
            }

            return sb.ToString().Trim();
        }
    }
}
