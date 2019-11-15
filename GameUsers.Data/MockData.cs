using GameUsers.Domain;
using System.Collections.Generic;

namespace GameUsers.Data
{
    public static class MockData
    {
        public static IEnumerable<User> GetUsers()
        {
            var users = new List<User> {

                User.CreateUser(1,  "Bob", "Smith", "bob@bob", "0121"),
                User.CreateUser(2,  "Fred", "Basset", "fred@fred", "65465"),
                User.CreateUser(3,  "Ole", "Biscuit Barrel", "asdf@asdf", "456789"),
                User.CreateUser(4,  "Luxury", "Yatch", "asfd@asf", "564654")

             };


            return users;
        }


        public static IEnumerable<LeaderboardEntry> GetLeaderboardEntries()
        {
            var leaderBoardEntries = new List<LeaderboardEntry>() {
                LeaderboardEntry.CreateLeaderboardEntry(1, 45, 456),
                LeaderboardEntry.CreateLeaderboardEntry(2, 344, 234),
                LeaderboardEntry.CreateLeaderboardEntry(3, 567, 40),
                LeaderboardEntry.CreateLeaderboardEntry(4, 200, 324)
            };

            return leaderBoardEntries;
        }
    }
}
