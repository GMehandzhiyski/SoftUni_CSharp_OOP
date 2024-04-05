using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;
        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();  
        }



        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }

                name = value;
            }
        }
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                capacity = value;
            }
        }

        public IReadOnlyCollection<ILoan> Loans => loans;

        public IReadOnlyCollection<IClient> Clients => clients;
        public double SumRates()
        {
            if (Loans.Count == 0)
            {
                return 0;
            }
            return loans.Sum(l => l.InterestRate );
    
        }

        public void AddClient(IClient Client)
        {
            if (clients.Count < capacity)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
          
        }
        public void RemoveClient(IClient Client)
        {
            clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {GetType().Name}");
            if (clients.Any())
            {
                sb.Append("Clients: ");
                foreach (var client in clients)
                {
                    sb.Append($"{client.Name}" + ", ");
                }

                sb.Length -= 2;
            }
            else
            {
                sb.Append("Clients: none");
            }
            sb.AppendLine();
            sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {SumRates()}."); 

            return sb.ToString().Trim();
        }


    }
}
