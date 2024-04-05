using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> loansRepository;
        private IRepository<IBank> banksRepository;
        public Controller()
        {
            loansRepository = new LoanRepository();
            banksRepository = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
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

            banksRepository.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded,bankTypeName);
        }
        public string AddLoan(string loanTypeName)
        {

            ILoan loan;
            if (loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }

            else if (loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }

            else 
            {
                throw new ArgumentException(string.Format(ExceptionMessages.LoanTypeInvalid));
            }
       

            loansRepository.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }
        public string ReturnLoan(string bankName, string loanTypeName)
        {
           IBank currBank = banksRepository.FirstModel(bankName);
           ILoan currLoan = loansRepository.FirstModel(loanTypeName);

            if (currLoan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }
                
            currBank.AddLoan(currLoan);
            loansRepository.RemoveModel(currLoan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully,loanTypeName,bankName);

        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IBank currBank = banksRepository.FirstModel(bankName);
            IClient currClient = default;

            if ((currBank.GetType().Name == nameof(BranchBank) && clientTypeName != nameof(Student)) ||
                  (currBank.GetType().Name == nameof(CentralBank) && clientTypeName != nameof(Adult)))
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }

            
            if (clientTypeName == nameof(Student))
            {
                currClient = new Student(clientName, id, income);
            }
            else if (clientTypeName == nameof(Adult))
            {
                currClient = new Adult(clientName, id, income);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ClientTypeInvalid));
            }

            

        
            currBank.AddClient(currClient);
            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);

        }


        public string FinalCalculation(string bankName)
        {
            IBank currBank = banksRepository.FirstModel(bankName);
          
            double sumOfloans = 0;

            foreach (var loan in currBank.Loans)
            {
                sumOfloans += loan.Amount; 
            }

            double sumOfIncome = 0;
            foreach (var client in currBank.Clients)
            {
                sumOfIncome += client.Income;
            }

            double funds = Math.Round((sumOfloans + sumOfIncome),2);


            return string.Format(OutputMessages.BankFundsCalculated,bankName,funds);
        }


        public string Statistics()
        {
            StringBuilder   sb = new StringBuilder();   
            foreach (var currBank in banksRepository.Models)
            {
                sb.AppendLine(currBank.GetStatistics());
            }


            return sb.ToString().Trim();   
        }
    }
}
