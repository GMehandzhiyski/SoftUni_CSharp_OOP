using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string username ;
        private int followers;
        private double engagementRate;
        private double income;
        private List<string> participations;

        protected Influencer(string username, int followers, double engagementRate)
        {
            Username = username;    
            Followers = followers;  
            EngagementRate = engagementRate;
            income = 0;
            participations = new List<string>();    
        }

        public string Username
        {
            get { return username; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.UsernameIsRequired));
                }
                username = value; 
            }
        }

        public int Followers
        {
            get { return followers; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FollowersCountNegative));
                }
                followers = value;
            }
        }

        public double EngagementRate
        {
            get { return engagementRate; }
            private set
            {
                engagementRate = value;
            }
        }
        public double Income
        {
            get { return income; }
            private set
            {
                income = value;
            }
        }
        public IReadOnlyCollection<string> Participations => participations.AsReadOnly();

        public abstract int CalculateCampaignPrice();

        public void EarnFee(double amount)
        {
            Income += amount;
        }

        public void EndParticipation(string brand)
        {
           participations.Remove(brand);
        }

        public void EnrollCampaign(string brand)
        {
           participations.Add(brand);
        }

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
