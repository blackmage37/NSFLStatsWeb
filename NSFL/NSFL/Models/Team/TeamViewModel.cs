using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSFL.Models.Team
{
    public class TeamViewModel
    {
        [MaxLength(50)]
        [DisplayName("Team name")]
        public string TeamName { get; set; }

        //[DisplayName("Team TPE")]
        //public int TeamTPE { get; set; }

        [DisplayName("Players")]
        public List<Player.PlayerViewModel> Players { get; set; }
    }
}