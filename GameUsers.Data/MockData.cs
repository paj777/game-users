using GameUsers.Domain;
using System.Collections.Generic;

namespace GameUsers.Data
{
    public static class MockData
    {
        public static IEnumerable<User> GetUsers()
        {
            var users = new List<User> {
                new User {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Smith"
                },
                new User {
                    Id = 2,
                    FirstName = "Fred",
                    LastName = "Basset"
                },
                new User {
                    Id = 3,
                    FirstName = "Luxury",
                    LastName = "Yatch"
                },
                new User {
                    Id = 4,
                    FirstName = "Ole",
                    LastName = "Biscuit Barrel"
                }
             };


            return users;
        }


        public static IEnumerable<LeaderboardEntry> GetLeaderboardEntries()
        {
            var leaderBoardEntries = new List<LeaderboardEntry>() {
                new LeaderboardEntry
                {
                    UserId = 1,
                    GamesPlayed = 50,
                    Score = 100
                },
                new LeaderboardEntry
                {
                    UserId = 2,
                    GamesPlayed = 12,
                    Score = 56
                },
                new LeaderboardEntry
                {
                    UserId = 3,
                    GamesPlayed = 67,
                    Score = 210
                },
                new LeaderboardEntry
                {
                    UserId = 4,
                    GamesPlayed = 75,
                    Score = 315
                },
                new LeaderboardEntry
                {
                    UserId = 5,
                    GamesPlayed = 34,
                    Score = 234
                }
            };

            return leaderBoardEntries;
        }
    }
}
