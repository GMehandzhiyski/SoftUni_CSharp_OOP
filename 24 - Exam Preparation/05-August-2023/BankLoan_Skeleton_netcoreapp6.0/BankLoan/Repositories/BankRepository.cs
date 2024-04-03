using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        public IReadOnlyCollection<IBank> Models => throw new NotImplementedException();

        public void AddModel(IBank model)
        {
            throw new NotImplementedException();
        }

        public IBank FirstModel(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveModel(IBank model)
        {
            throw new NotImplementedException();
        }
    }
}
