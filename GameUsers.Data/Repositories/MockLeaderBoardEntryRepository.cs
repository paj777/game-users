using GameUsers.Core.Interfaces;
using GameUsers.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameUsers.Data.Repositories
{
    public class MockLeaderBoardEntryRepository : IRepository<LeaderboardEntry>
    {
        private readonly IList<LeaderboardEntry> _leaderboardEntries = MockData.GetLeaderboardEntries().ToList();

        public void Create(LeaderboardEntry entity)
        {
            _leaderboardEntries.Add(entity);
        }

        public void Delete(int userId)
        {
            var leaderBoardEntry = _leaderboardEntries.Where(x => x.UserId == userId).FirstOrDefault();

            if (leaderBoardEntry != null)
            {
                _leaderboardEntries.Remove(leaderBoardEntry);
            }
        }

        public async Task<IEnumerable<LeaderboardEntry>> GetAll()
        {
            return _leaderboardEntries;
        }

        public LeaderboardEntry GetById(int userId)
        {
            return _leaderboardEntries.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public void Update(LeaderboardEntry entity)
        {
            var user = _leaderboardEntries.Where(x => x.UserId == entity.UserId).FirstOrDefault();

            user = entity;
        }
    }
}
