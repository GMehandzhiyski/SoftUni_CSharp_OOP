﻿using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> loans;

        public LoanRepository()
        {
            loans = new List<ILoan>();  
        }

        public IReadOnlyCollection<ILoan> Models => loans;

        public void AddModel(ILoan loan)
        {
           loans.Add(loan); 
        }
        public bool RemoveModel(ILoan model)
        {
            return loans.Remove(model); 
        }

        public ILoan FirstModel(string name)
        {
            return loans.FirstOrDefault(l => l.GetType().Name == name);
        }

    }
}
