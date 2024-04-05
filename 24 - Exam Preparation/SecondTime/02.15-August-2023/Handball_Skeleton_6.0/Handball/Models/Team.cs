using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private double overallRating;
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            pointsEarned = 0;
            players = new List<IPlayer>();  
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.TeamNameNull));
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get { return pointsEarned; }
            private set
            {
                pointsEarned = value;
            }
        }

        public double OverallRating
        {
            get
            {
                
                if (players.Count > 0)
                {
                    double overalRating = players.Average(p => p.Rating);
                    return Math.Round(overalRating, 2);
                }
                else 
                {
                    return 0;
                }
               
               
            }
            private set
            {
                overallRating = value;
            }
        }

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Draw()
        {
            PointsEarned += 1;
            IPlayer currGoalkeeper = players.FirstOrDefault(g => g.GetType().Name == nameof(Goalkeeper));
            currGoalkeeper.IncreaseRating();
        }

        public void Lose()
        {
            foreach (var currPlayer in players)
            {
                currPlayer.DecreaseRating();
            }
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

        public override string ToString()
        {   
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            if (players.Any())
            {
                sb.Append($"--Players: ");
                foreach (var currPlayer in players)
                {
                    sb.Append(currPlayer.Name + ", ");
                }
                sb.Length -= 2;
            }
            else
            {
                sb.AppendLine($"--Players: none");
            }

            return sb.ToString().Trim();
        }
    }
}
