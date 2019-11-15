namespace GameUsers.Domain
{
    public class LeaderboardEntry
    {
        private LeaderboardEntry(int userId, int score, int gamesPlayed)
        {
            UserId = userId;
            Score = score;
            GamesPlayed = gamesPlayed;
        }

        public static LeaderboardEntry CreateLeaderboardEntry(int userId, int score, int gamesPlayed)
        {
            return new LeaderboardEntry(userId, score, gamesPlayed);
        }

        public int UserId { get; set; }
        public int Score { get; set; }
        public int GamesPlayed { get; set; }
    }
}
