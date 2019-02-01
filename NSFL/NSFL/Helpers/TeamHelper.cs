using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace NSFL.Helpers
{
    public static class TeamHelper
    {
        public const string TEAMFILESPATH = @"~/Team Files/";
        public const int TEAMCOUNT = 9;

        public static string[] GetTeamPrefixes()
        {
            var teamPrefixes = new string[TEAMCOUNT];
            teamPrefixes[0] = "AO";
            teamPrefixes[1] = "BH";
            teamPrefixes[2] = "CY";
            teamPrefixes[3] = "NO";
            teamPrefixes[4] = "OCO";
            teamPrefixes[5] = "PL";
            teamPrefixes[6] = "SJS";
            teamPrefixes[7] = "YW";
            teamPrefixes[8] = "FA";

            return teamPrefixes;
        }

        public static Dictionary<string, string> GetTeamPlayerFiles()
        {
            var playerFiles = new Dictionary<string, string>();
            var prefixes = GetTeamPrefixes();

            for (int i = 0; i < prefixes.Length; i++)
            {
                playerFiles.Add(GetTeamNameFromPrefix(prefixes[i]), string.Format("{0}{1}Players.txt", TEAMFILESPATH, prefixes[i]));
            }

            return playerFiles;
        }

        public static string GetTeamNameFromPrefix(string prefix)
        {
            if (prefix == "AO") { return "Arizona Outlaws"; }
            if (prefix == "BH") { return "Baltimore Hawks"; }
            if (prefix == "CY") { return "Colorado Yeti"; }
            if (prefix == "NO") { return "New Orleans Second Line"; }
            if (prefix == "OCO") { return "Orange County Otters"; }
            if (prefix == "PL") { return "Philadelphia Liberty"; }
            if (prefix == "SJS") { return "San Jose SaberCats"; }
            if (prefix == "YW") { return "Yellowknife Wraiths"; }
            if (prefix == "FA") { return "Free Agents"; }

            return "";
        }

        public static string[] GetTeamTPEFiles()
        {
            var teamFiles = new string[TEAMCOUNT];
            var prefixes = GetTeamPrefixes();

            for (int i = 0; i < prefixes.Length; i++)
            {
                teamFiles[i] = string.Format("{0}{1}Team.txt", TEAMFILESPATH, prefixes[i]);
            }

            return teamFiles;
        }
    }
}