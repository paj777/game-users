using GameUsers.Core.Interfaces;
using GameUsers.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameUsers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly IRepository<LeaderboardEntry> _leaderBoardRepository;

        public LeaderboardController(IRepository<LeaderboardEntry> leaderBoardRepository)
        {
            _leaderBoardRepository = leaderBoardRepository;
        }

        // GET api/leaderboardentry
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var leaderboardEntries =  await _leaderBoardRepository.GetAll();            

            return Ok(leaderboardEntries);
        }
    }
}