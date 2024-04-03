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
        private List<IBank> banks;


        public IReadOnlyCollection<IBank> Models => banks.AsReadOnly();

        public BankRepository()
        {
            banks = new List<IBank>();
        }

        public void AddModel(IBank model)
        {
            banks.Add(model);
        }
        public bool RemoveModel(IBank model)
        {
            return banks.Remove(model);
        }

        public IBank FirstModel(string name)
        {
           return banks.FirstOrDefault(x => x.Name == name);
        }

    }
}
