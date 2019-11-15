namespace GameUsers.Domain
{
    public class LeaderboardEntry
    {
        public int UserId { get; set; }
        public int Score { get; set; }
        public int GamesPlayed { get; set; }
    }
}
