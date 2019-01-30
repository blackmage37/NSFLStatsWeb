using NSFL.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSFL.Helpers
{
    public static class PlayerHelper
    {
        public static Player GetPlayerFromPlayerLine(PlayerFileLine playerFileLine)
        {
            try
            {
                if (playerFileLine.PlayerLine.Split('-').Length < 2 || playerFileLine.PlayerLine.Split(',').Length < 2 || !playerFileLine.PlayerLine.Trim().StartsWith("("))
                {
                    return new Player(); // Probably an inconsistenly formatted roster title or announcement
                }

                var player = new Player();

                player.PlayerSeasonDrafted = playerFileLine.PlayerLine.Split(')')[0].Replace("(", "").Trim();

                // if the player has a three word name
                if (playerFileLine.PlayerLine.Split('-')[1].Trim().Split(' ').Length > 2)
                {
                    player.PlayerFirstName = playerFileLine.PlayerLine.Split('-')[1].Trim().Split(' ')[0].Trim();
                    player.PlayerFirstName = player.PlayerFirstName + " " + playerFileLine.PlayerLine.Split('-')[1].Trim().Split(' ')[1].Trim();
                    player.PlayerLastName = playerFileLine.PlayerLine.Split('-')[1].Trim().Split(' ')[2].Trim();
                }
                // standard firstname lastname
                else if (playerFileLine.PlayerLine.Split('-')[1].Trim().Split(' ').Length > 1)
                {
                    player.PlayerFirstName = playerFileLine.PlayerLine.Split('-')[1].Trim().Split(' ')[0].Trim();
                    player.PlayerLastName = playerFileLine.PlayerLine.Split('-')[1].Trim().Split(' ')[1].Trim();
                }
                else // A last name is not required, prevent this player from being ommitted
                {
                    player.PlayerFirstName = playerFileLine.PlayerLine.Split('-')[1].Trim().Split(' ')[0].Trim();
                    player.PlayerLastName = "";
                }
                player.PlayerTPE = int.Parse(playerFileLine.PlayerLine.Split(',')[1].Split(':').Last().Trim());
                player.PlayerPosition = playerFileLine.PlayerLine.Split('-').Last().Split(',')[0].Trim();
                player.PlayerProfileURL = playerFileLine.PlayerLine.Split(',')[2].Trim();

                return player;
            }
            catch
            {
                return new Player();
            }
        }
    }
}