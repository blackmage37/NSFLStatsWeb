using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSFL.Models.Player
{
    public class PlayerViewModel
    {
        [DisplayName("Team")]
        public string TeamName { get; set; }

        [DisplayName("Drafted")]
        public string PlayerSeasonDrafted { get; set; }

        [DisplayName("First name")]
        public string PlayerFirstName { get; set; }

        [DisplayName("Last name")]
        public string PlayerLastName { get; set; }

        [DisplayName("TPE")]
        public int PlayerTPE { get; set; }

        [DisplayName("ID")]
        public int PlayerID { get; set; }

        [MaxLength(2)]
        [DisplayName("Position")]
        public string PlayerPosition { get; set; }

        [DisplayName("Name")]
        public string PlayerFullName
        {
            get
            {
                return string.Format("{0} {1}", PlayerFirstName, PlayerLastName);
            }
        }

        public string PlayerProfileURL { get; set; }
    }
}