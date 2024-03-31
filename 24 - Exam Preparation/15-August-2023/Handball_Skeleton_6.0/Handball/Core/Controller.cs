using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;
        private string[] validPalyers = {"CenterBack", "Goalkeeper", "ForwardWing"}; 

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();   
        }
        public string NewTeam(string name)
        {
            Team team = new(name);

            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, "TeamRepository");
            }
            teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, "TeamRepository");
        }
        public string NewPlayer(string typeName, string name)
        {
            if (!validPalyers.Contains(typeName))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (validPalyers.Contains(name))
            {
                IPlayer existingPlayer = players.GetModel(name);
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, players.GetType().Name,
                    existingPlayer.GetType().Name);
            }

            IPlayer newPlayer = null;

            if (typeName == "Goalkeeper")
            {
                newPlayer = new Goalkeeper(name);
            }
            if (typeName == "ForwardWing")
            {
                newPlayer = new ForwardWing(name);
            }
            if (typeName == "CenterBack")
            {
                newPlayer = new CenterBack(name);
            }

            players.AddModel(newPlayer);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }
        public string NewContract(string playerName, string teamName)
        {
            bool check =  players.ExistsModel(playerName);
            if (!check)
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName,typeof(PlayerRepository).Name);
            }

            if (!teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting,teamName, typeof(TeamRepository).Name);
            }

            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);

            if (player.Team != null) 
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(team.Name);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract,playerName, teamName);
        }
        public string NewGame(string firstTeamName, string secondTeamName)
        {
           ITeam firstTeam = teams.GetModel(firstTeamName);
           ITeam secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating == secondTeam.OverallRating)
            {
                firstTeam.Draw();
                secondTeam.Draw();

                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }

            else if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }
            else
            {
                secondTeam.Win();
                firstTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }
         
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");

            ITeam team = teams.GetModel(teamName);
            List<IPlayer> players = team.Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name)
                .ToList();

            
          

            foreach (IPlayer player in players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();   
        }

        public string LeagueStandings()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***League Standing***"); 

            List<ITeam> sortedTeams = teams.Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name)
                .ToList();

            

            foreach (var team in sortedTeams)
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }





    }
}
