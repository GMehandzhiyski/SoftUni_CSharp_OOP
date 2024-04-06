using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> playerRepository;
        private IRepository<ITeam> teamRepository;

        public Controller()
        {
            playerRepository = new PlayerRepository();
            teamRepository = new TeamRepository();

        }


        public string NewTeam(string name)
        {
            ITeam team;

            if (teamRepository.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
            }

            team = new Team(name);
            teamRepository.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));
        }
        public string NewPlayer(string typeName, string name)
        {
           
            IPlayer player = playerRepository.GetModel(name);
            if (player != null )
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded,name,nameof(PlayerRepository),player.GetType().Name);
            }

            IPlayer newPlayer;

            if (typeName == nameof(Goalkeeper))
            {
                newPlayer = new Goalkeeper(name);
            }
            else if (typeName == nameof(CenterBack))
            {
                newPlayer = new CenterBack(name);
            }
            else if (typeName == nameof(ForwardWing))
            {
                newPlayer = new ForwardWing(name);
            }
            else
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            playerRepository.AddModel(newPlayer);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }
        public string NewContract(string playerName, string teamName)
        {
            if (!playerRepository.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting,playerName, nameof(PlayerRepository));
            }

            if (!teamRepository.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            IPlayer currPlayer = playerRepository.GetModel(playerName);
            ITeam currTeam = teamRepository.GetModel(teamName);
            if (currPlayer.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, currPlayer.Team);
            }

            currPlayer.JoinTeam(teamName);
            currTeam.SignContract(currPlayer);
            return string.Format(OutputMessages.SignContract, playerName,teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teamRepository.GetModel(firstTeamName);
            ITeam secondTeam = teamRepository.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeam.Name,secondTeam.Name);
            }
            else if (secondTeam.OverallRating > firstTeam.OverallRating)
            {
                secondTeam.Win();
                firstTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, secondTeam.Name, firstTeam.Name);
            }

            firstTeam.Draw();
            secondTeam.Draw();
            return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);

        }

        public string PlayerStatistics(string teamName)
        {
          StringBuilder sb = new StringBuilder();   

            ITeam currTeam = teamRepository.GetModel(teamName);

            var sortedPayers = currTeam.Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name);

            sb.AppendLine($"***{teamName}***");

            foreach (var currPlayer in sortedPayers)
            {
                sb.AppendLine(currPlayer.ToString());
            }

            return sb.ToString().Trim();
        }
    

        public string LeagueStandings()
        {
           StringBuilder sb = new StringBuilder();

            var sortedTeams = teamRepository
                .Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t )
                .ThenBy(t => t.Name);

            sb.AppendLine("***League Standings***");

            foreach (var team in sortedTeams) 
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }





    }
}
