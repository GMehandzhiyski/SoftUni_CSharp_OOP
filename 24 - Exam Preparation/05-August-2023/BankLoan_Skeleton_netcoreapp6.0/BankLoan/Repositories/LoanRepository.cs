using BankLoan.Models.Contracts;
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
        public IReadOnlyCollection<ILoan> Models => throw new NotImplementedException();

        public void AddModel(ILoan model)
        {
            throw new NotImplementedException();
        }

        public ILoan FirstModel(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveModel(ILoan model)
        {
            throw new NotImplementedException();
        }
    }
}
