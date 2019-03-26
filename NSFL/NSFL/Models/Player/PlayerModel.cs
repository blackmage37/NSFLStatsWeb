namespace NSFL.Models.Player
{
    public class Player
    {
        public string PlayerSeasonDrafted { get; set; }

        public string PlayerFirstName { get; set; }

        public string PlayerLastName { get; set; }

        public int PlayerTPE { get; set; }

        public int PlayerID { get; set; }

        public string PlayerPosition { get; set; }

        public string PlayerProfileURL { get; set; }
    }

    public class PlayerFileLine
    {
        public PlayerFileLine()
        { }

        public PlayerFileLine(string playerLine)
        {
            PlayerLine = playerLine;
        }

        public string PlayerLine { get; set; }
    }
}