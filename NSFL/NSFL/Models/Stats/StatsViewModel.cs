using System.Collections.Generic;

namespace NSFL.Models.Stats
{
    public class TeamTPEViewModel
    {
        public List<Team.TeamViewModel> Teams { get; set; }

        public List<Player.PlayerViewModel> AllPlayers { get; set; }

        public string lastUpdated { get; set; }

    }
}