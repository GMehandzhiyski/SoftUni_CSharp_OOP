using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Data;
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
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException(string.Format(ExceptionMessages.BankNameNullOrWhiteSpace));
                }
                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public IReadOnlyCollection<ILoan> Loans => loans;

        public IReadOnlyCollection<IClient> Clients => clients;

        public double SumRates()
        {
            double sumRates = 0;
            foreach (var loan in loans)
            {
                sumRates += loan.InterestRate;
            }

            return sumRates;
        }

        public void AddClient(IClient Client)
        {
            if (clients.Count < capacity)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotEnoughCapacity));
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

            sb.AppendLine($"Name: {name}, Type: {GetType().Name}");

            if (clients.Count > 0)
            {
                foreach (var client in clients)
                {
                    sb.Append(client.Name);
                    sb.Append(", ");
                }

                sb.ToString().TrimEnd(',', ' ');
            }
            else
            {
                sb.AppendLine("Clients: none");
            }

            sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {loans.Sum(l => l.InterestRate)}");


            return sb.ToString().Trim();
        }

    }
}
