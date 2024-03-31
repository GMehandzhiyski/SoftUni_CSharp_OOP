using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            players = new List<IPlayer>();
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    string.Format(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }

        }

        public int PointsEarned
        {
            get { return pointsEarned; }

            private set { pointsEarned = value; }
        }

        public double OverallRating
        {
            get
            {
                if (!players.Any())
                {
                    return 0;
                }

                return Math.Round(players.Average(p => p.Rating), 2);

            }

            //private set { pointsEarned = value; }
        }

        public IReadOnlyCollection<IPlayer> Players
        {
            get { return players.AsReadOnly(); }
        }

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }
        public void Win()
        {
            PointsEarned += 3;
            foreach (var currPlayer in players)
            {
                currPlayer.IncreaseRating();
            }
        }
        public void Lose()
        {
            foreach (var currPlayer in players)
            {
                currPlayer.DecreaseRating();
            }
        }

        public void Draw()
        {
            PointsEarned += 1;
            IPlayer goalKeeper = players.FirstOrDefault(p => p is Goalkeeper);

            if (goalKeeper != null)
            {
                goalKeeper.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.AppendLine($"Players:");
            if (players != null)
            {
                sb.Append("none");
            }
            else
            {
                foreach (var currPlayer in players)
                {
                    sb.Append($"{currPlayer.Name}, ");
                }
            }
            return sb.ToString().TrimEnd(',',' ');
        }

    }
}
