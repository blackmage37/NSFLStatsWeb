using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace NSFL.Helpers
{
    public static class PositionHelper
    {

        public static string[] GetPositionAbbreviations()
        {
            var positionAbbreviations = new string[20];

            positionAbbreviations[0] = "QB";
            positionAbbreviations[1] = "RB";
            positionAbbreviations[2] = "FB";
            positionAbbreviations[3] = "WR";
            positionAbbreviations[4] = "TE";
            positionAbbreviations[5] = "OL";
            positionAbbreviations[6] = "T";
            positionAbbreviations[7] = "G";
            positionAbbreviations[8] = "C";
            positionAbbreviations[9] = "DE";
            positionAbbreviations[10] = "DT";
            positionAbbreviations[11] = "DL";
            positionAbbreviations[12] = "LB";
            positionAbbreviations[13] = "FS";
            positionAbbreviations[14] = "SS";
            positionAbbreviations[15] = "S";
            positionAbbreviations[16] = "CB";
            positionAbbreviations[17] = "K";
            positionAbbreviations[18] = "P";
            positionAbbreviations[19] = "K/P";

            return positionAbbreviations;
        }

        public static Dictionary<string, string> GetPositions()
        {
            var playerPositions = new Dictionary<string, string>();
            var abbrevs = GetPositionAbbreviations();

            for (int i = 0; i < abbrevs.Length; i++)
            {
                playerPositions.Add(abbrevs[i], GetPositionFromAbbrev(abbrevs[i]));
            }

            return playerPositions;
            
        }

        public static string GetPositionFromAbbrev(string abbrev)
        {

            if (abbrev == "QB") { return "Quarterback"; }
            if (abbrev == "RB") { return "Runningback"; }
            if (abbrev == "FB") { return "Fullback"; }
            if (abbrev == "WR") { return "Wide Receiver"; }
            if (abbrev == "TE") { return "Tight End"; }
            if (abbrev == "OL") { return "Offensive Line"; }
            if (abbrev == "T") { return "Offensive Line"; }
            if (abbrev == "G") { return "Offensive Line"; }
            if (abbrev == "C") { return "Offensive Line"; }
            if (abbrev == "DE") { return "Defensive Line"; }
            if (abbrev == "DT") { return "Defensive Line"; }
            if (abbrev == "DL") { return "Defensive Line"; }
            if (abbrev == "LB") { return "Linebacker"; }
            if (abbrev == "FS") { return "Safety"; }
            if (abbrev == "SS") { return "Safety"; }
            if (abbrev == "S") { return "Safety"; }
            if (abbrev == "CB") { return "Cornerback"; }
            if (abbrev == "K") { return "Kicker"; }
            if (abbrev == "P") { return "Kicker"; }
            if (abbrev == "K/P") { return "Kicker"; }

            return "";
        }

    }
}