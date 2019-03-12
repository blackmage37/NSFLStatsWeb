using NSFL.Helpers;
using NSFL.Models.Player;
using NSFL.Models.Stats;
using NSFL.Models.Team;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NSFL.Controllers
{
    public class StatsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TeamTPE()
        {
            var viewModel = new TeamTPEViewModel();
            viewModel.Teams = new List<TeamViewModel>();
            viewModel.AllPlayers = new List<PlayerViewModel>();
            viewModel.lastUpdated = DateTimeHelper.GetDateTimeFromFile(@"~/Team Files/record.json");

            var playerFiles = TeamHelper.GetTeamPlayerFiles();
            foreach (var file in playerFiles)
            {
                if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(file.Value)))
                {
                    var team = new TeamViewModel();
                    team.TeamName = file.Key;
                    team.Players = new List<PlayerViewModel>();

                    var lines = System.IO.File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath(file.Value));
                    foreach (var line in lines)
                    {
                        var playerFileLine = new PlayerFileLine(line);

                        var playerData = PlayerHelper.GetPlayerFromPlayerLine(playerFileLine);
                        if (string.IsNullOrEmpty(playerData.PlayerFirstName))
                        {
                            continue;
                        }

                        var player = new PlayerViewModel();
                        player.PlayerID = playerData.PlayerID;
                        player.PlayerFirstName = playerData.PlayerFirstName;
                        player.PlayerLastName = playerData.PlayerLastName;
                        player.PlayerPosition = playerData.PlayerPosition;
                        player.PlayerSeasonDrafted = playerData.PlayerSeasonDrafted;
                        player.PlayerTPE = playerData.PlayerTPE;
                        player.TeamName = team.TeamName;
                        player.PlayerProfileURL = playerData.PlayerProfileURL;

                        team.Players.Add(player);
                        viewModel.AllPlayers.Add(player);
                    }

                    //var teamTPE = 0;

                    // TODO: convert this to read from the team file rather than using another loop to calculate
                    //foreach (var player in team.Players)
                    //{
                    //    teamTPE += player.PlayerTPE;
                    //}
                    //team.TeamTPE = teamTPE;

                    viewModel.Teams.Add(team);
                }
            }

            return View(viewModel);
        }

        public ActionResult PlayerTPE(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}