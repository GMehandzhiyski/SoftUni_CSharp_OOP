using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        public string Name => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public IReadOnlyCollection<ILoan> Loans => throw new NotImplementedException();

        public IReadOnlyCollection<IClient> Clients => throw new NotImplementedException();

        public void AddClient(IClient Client)
        {
            throw new NotImplementedException();
        }

        public void AddLoan(ILoan loan)
        {
            throw new NotImplementedException();
        }

        public string GetStatistics()
        {
            throw new NotImplementedException();
        }

        public void RemoveClient(IClient Client)
        {
            throw new NotImplementedException();
        }

        public double SumRates()
        {
            throw new NotImplementedException();
        }
    }
}
