using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencerRepository;
        private IRepository<ICampaign> campingRepository;

        public Controller()
        {
            influencerRepository = new InfluencerRepository();
            campingRepository = new CampaignRepository();

        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            IInfluencer newInfluencer;

            if (influencerRepository.FindByName(username) != null )
            {
                return string.Format(OutputMessages.UsernameIsRegistered,username,nameof(InfluencerRepository));
            }

            if (typeName == nameof(BusinessInfluencer))
            {
                newInfluencer = new BusinessInfluencer(username, followers);
            }
            else if ((typeName == nameof(FashionInfluencer)))
            {
                newInfluencer = new FashionInfluencer(username, followers);

            }
            else if ((typeName == nameof(BloggerInfluencer)))
            { 
                newInfluencer = new BloggerInfluencer(username, followers);
            }
            else 
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            influencerRepository.AddModel(newInfluencer);
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully,username);
        }
        public string BeginCampaign(string typeName, string brand)
        {
            ICampaign newCamping;

            if (campingRepository.FindByName(brand) != null )
            {
                return string.Format(OutputMessages.CampaignDuplicated,brand);
            }

            if (typeName == nameof(ProductCampaign))
            {
                newCamping = new ProductCampaign(brand);
            }
            else if (typeName == nameof(ServiceCampaign))
            { 
                newCamping = new ServiceCampaign(brand);
            }
            else
            { 
             return string.Format(OutputMessages.CampaignTypeIsNotValid,typeName);
            }

            campingRepository.AddModel(newCamping);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }
        public string AttractInfluencer(string brand, string username)
        {
            ICampaign currCamping = campingRepository.FindByName(brand);
            IInfluencer currInfluencer = influencerRepository.FindByName(username);

            if (currInfluencer == null) 
            {
                return string.Format(OutputMessages.InfluencerNotFound,nameof(InfluencerRepository),username);
            }

            if (currCamping == null)
            {
                return string.Format(OutputMessages.CampaignNotFound,brand);
            }

            if (currCamping.Contributors.Count  != 0 )
            {
                foreach (var currInf in currCamping.Contributors)
                {
                    if (currInf == currInfluencer.Username)
                    {
                        return string.Format(OutputMessages.InfluencerAlreadyEngaged,username,brand);
                    }
                }
            }

            if (!(currCamping.GetType().Name == nameof(ProductCampaign) 
                && (currInfluencer.GetType().Name == nameof(BusinessInfluencer) || currInfluencer.GetType().Name == nameof(FashionInfluencer)))
                && !(currCamping.GetType().Name == nameof(ServiceCampaign)
                && (currInfluencer.GetType().Name == nameof(BusinessInfluencer) || currInfluencer.GetType().Name == nameof(BloggerInfluencer))))
          
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign,username,brand);
            }

            if (currCamping.Budget < currInfluencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            var amountInf = currInfluencer.CalculateCampaignPrice();
            currInfluencer.EarnFee(amountInf);
            currInfluencer.EnrollCampaign(brand);

            currCamping.Engage(currInfluencer);


            return string.Format(OutputMessages.InfluencerAttractedSuccessfully,username,brand);
        }
        public string FundCampaign(string brand, double amount)
        {
            ICampaign currCamping = campingRepository.FindByName(brand);
            if (currCamping == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount < 1)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }

            currCamping.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully,brand,amount);

        }
        public string CloseCampaign(string brand)
        {
            ICampaign currCamping = campingRepository.FindByName(brand);
            if (currCamping == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToClose);
            }

            if (currCamping.Budget <= 10_000)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }
            else if (currCamping.Budget > 10_000)
            {
                foreach (var currInfCamp in currCamping.Contributors)
                {
                    IInfluencer currInfl = influencerRepository.FindByName(currInfCamp);
                    currInfl.EarnFee(2_000);
                    currInfl.EndParticipation(currCamping.Brand);
                }
            
            }

            campingRepository.RemoveModel(currCamping);
           return string.Format(OutputMessages.CampaignClosedSuccessfully,brand);
        }
        public string ConcludeAppContract(string username)
        {
            IInfluencer currInfluencer = influencerRepository.FindByName(username);

            if (currInfluencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned,username);
            }

            foreach (var currCamp in campingRepository.Models)
            {
                foreach (var campInl in currCamp.Contributors)
                {
                    if (campInl == currInfluencer.Username)
                    {
                        return string.Format(OutputMessages.InfluencerHasActiveParticipations,username);
                    }
                }
            }

            influencerRepository.RemoveModel(currInfluencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully,username);
        }

        public string ApplicationReport()
        {

            StringBuilder sb = new StringBuilder(); 

            var sortedInfluecer = influencerRepository
                .Models
                .OrderByDescending(i => i.Income)
                .ThenByDescending(f => f.Followers);

             foreach (var currInfl in sortedInfluecer)
            {
                sb.AppendLine(currInfl.ToString());

                if(currInfl.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");

                    foreach (var partString in currInfl.Participations.OrderBy(t => t))
                    {
                        ICampaign currCampin = campingRepository.FindByName(partString);

                        sb.AppendLine(currCampin.ToString());
                    }
                }
            }
                



            return sb.ToString().Trim();


        }






    }
}
