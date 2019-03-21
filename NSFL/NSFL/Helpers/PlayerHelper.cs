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
            string[] pLine;

            try
            {
                if (playerFileLine.PlayerLine.Split('-').Length < 2 || playerFileLine.PlayerLine.Split(',').Length < 2 || !playerFileLine.PlayerLine.Trim().StartsWith("("))
                {
                    // Probably an inconsistenly formatted roster title or announcement
                    // TODO: use regex to check format of thread title, take the link and add to a separate array for easier error location
                    //       then print that array on an error page, with the links
                    return new Player(); 

                } else if (playerFileLine.PlayerLine.Split('-').Length > 3)
                {
                    // this would suggest there is probably a hyphen in the player name
                    
                    // so combine the middle two bits of the split
                    pLine = playerFileLine.PlayerLine.Split('-');
                    pLine[1] = pLine[1] + '-' + pLine[2];

                    // shift the last element up one place
                    pLine[2] = pLine[3];

                    // remove the last element of pLine
                    pLine = pLine.Take(pLine.Count() - 1).ToArray();
                        
                } else
                {
                    // this is the expected case, put the parts in an array
                    pLine = playerFileLine.PlayerLine.Split('-');
                }

                // create new player instance, with draft season
                var player = new Player
                {
                    PlayerSeasonDrafted = playerFileLine.PlayerLine.Split(')')[0].Replace("(", "").Trim()
                };

                // get the player name (and remove the nickname if there is one)
                if (pLine[1].IndexOf("&quot;") > 0)
                {

                    // find the start and end of the nickname part
                    int pStart = pLine[1].IndexOf("&quot;");
                    int pEnd = pLine[1].IndexOf("&quot;", pStart + 6);

                    // isolate the nickname part
                    string extract = pLine[1].Substring(pStart, pEnd - pStart + 7);

                    // remove it
                    pLine[1] = pLine[1].Replace(extract, "");

                }

                // if the player has a name longer than two words
                if (pLine[1].Trim().Split(' ').Length > 2)
                    {

                        // put first two "names" into first name
                        player.PlayerFirstName = pLine[1].Trim().Split(' ')[0].Trim();
                        player.PlayerFirstName = player.PlayerFirstName + " " + pLine[1].Trim().Split(' ')[1].Trim();
                                        
                        // all others into last name
                        player.PlayerLastName = pLine[1].Trim().Split(' ')[2].Trim();

                        for (int i = 2; i < pLine[1].Trim().Split(' ').Length; i++)
                        {
                            player.PlayerLastName = player.PlayerLastName + " " + pLine[1].Trim().Split(' ')[i + 1].Trim();
                        }

                    }
                    // standard firstname lastname
                    else if (pLine[1].Trim().Split(' ').Length > 1)
                    {
                        player.PlayerFirstName = pLine[1].Trim().Split(' ')[0].Trim();
                        player.PlayerLastName = pLine[1].Trim().Split(' ')[1].Trim();
                    }
                    else // A last name is not required, prevent this player from being ommitted
                    {
                        player.PlayerFirstName = pLine[1].Trim().Split(' ')[0].Trim();
                        player.PlayerLastName = "";
                    }

                // get TPE, Position and URL
                player.PlayerTPE = int.Parse(playerFileLine.PlayerLine.Split(',')[1].Split(':').Last().Trim());
                player.PlayerPosition = PositionHelper.GetPositionFromAbbrev(pLine.Last().Split(',')[0].Trim());
                player.PlayerProfileURL = playerFileLine.PlayerLine.Split(',')[2].Trim();

                // get the player ID (thread ID on the forum)
                if (int.TryParse(player.PlayerProfileURL.Split('=').Last().Trim(), out int iPID))
                {
                    player.PlayerID = iPID;
                }

                return player;

            }
            catch
            {
                return new Player();
            }
        }
    }
}