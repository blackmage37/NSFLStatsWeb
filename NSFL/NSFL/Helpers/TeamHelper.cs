using System.Collections.Generic;

namespace NSFL.Helpers
{
    public static class TeamHelper
    {
        public const string TEAMFILESPATH = @"~/Team Files/";
//        public const int TEAMCOUNT = 26;
        public const int TEAMCOUNT = 15;             // use this to import NSFL & DSFL only
//        public const int TEAMCOUNT = 9;             // use this to import NSFL only

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

            
             
            teamPrefixes[9] = "SA";
            teamPrefixes[10] = "KC";
            teamPrefixes[11] = "TL";
            teamPrefixes[12] = "PO";
            teamPrefixes[13] = "NS";
            teamPrefixes[14] = "PB";
        
        /*
            teamPrefixes[15] = "QB";
            teamPrefixes[16] = "RB";
            teamPrefixes[17] = "WR";
            teamPrefixes[18] = "TE";
            teamPrefixes[19] = "OL";
            teamPrefixes[20] = "DE";
            teamPrefixes[21] = "DT";
            teamPrefixes[22] = "LB";
            teamPrefixes[23] = "CB";
            teamPrefixes[24] = "SF";
            teamPrefixes[25] = "KP";
        */   

            return teamPrefixes;
        }

        public static Dictionary<string, string> GetTeamPlayerFiles()
        {
            var playerFiles = new Dictionary<string, string>();
            var prefixes = GetTeamPrefixes();

            for (int i = 0; i < prefixes.Length; i++)
            {
                playerFiles.Add(GetTeamNameFromPrefix(prefixes[i]), string.Format("{0}{1}Players.txt", TEAMFILESPATH + GetSubfolder(prefixes[i]), prefixes[i]));
            }

            return playerFiles;
        }

        private static string GetSubfolder(string v)
        {
            switch (v)
            {
                case "AO":
                case "BH":
                case "CY":
                case "NO":
                case "OCO":
                case "PL":
                case "SJS":
                case "YW":
                case "FA":
                    return "NSFL\\";

                case "TL":
                case "PO":
                case "SA":
                case "KC":
                case "NS":
                case "PB":
                    return "DSFL\\";

                case "QB":
                case "RB":
                case "WR":
                case "TE":
                case "OL":
                case "DE":
                case "DT":
                case "LB":
                case "CB":
                case "SF":
                case "KP":
                    return "By Pos\\";

                default: 
                       return "";
            }
          
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

            if (prefix == "TL") { return "Tijuana Luchadores"; }
            if (prefix == "PO") { return "Portland Pythons"; }
            if (prefix == "SA") { return "San Antonio Marshals"; }
            if (prefix == "KC") { return "Kansas City Coyotes"; }
            if (prefix == "NS") { return "Norfolk Seawolves"; }
            if (prefix == "PB") { return "Palm Beach Solar Bears"; }

            if (prefix == "QB") { return "Quarterback Prospects"; }
            if (prefix == "RB") { return "Runningback Prospects"; }
            if (prefix == "WR") { return "Wide Receiver Prospects"; }
            if (prefix == "TE") { return "Tight End Prospects"; }
            if (prefix == "OL") { return "Offensive Line Prospects"; }
            if (prefix == "DE") { return "Defensive End Prospects"; }
            if (prefix == "DT") { return "Defensive Tackle Prospects"; }
            if (prefix == "LB") { return "Linebacker Prospects"; }
            if (prefix == "CB") { return "Cornerback Prospects"; }
            if (prefix == "SF") { return "Safety Prospects"; }
            if (prefix == "KP") { return "Kicker and Punter Prospects"; }

            return "";
        }

        // removed team tpe for the time being; needs reworking to be properly functional
        // currently relies too heavily on correct thread title format on forum
        /*
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
        */
    }
}