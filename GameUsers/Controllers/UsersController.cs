using System.Linq;
using System.Threading.Tasks;
using GameUsers.Core.Interfaces;
using GameUsers.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GameUsers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UsersController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        
        public async Task<ActionResult> Get()
        {
            var users =  await _userRepository.GetAll();

            var result = users.Select(u => new { u.FirstName, u.LastName, u.Id }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null) {
                return new JsonResult(new { errormessage = $"User not found with id {id}", success = false });
            }

            return Ok(user);
        }

        [HttpPost("{id}/{first_name}/{last_name}/{email}/{telephone}")]
        public ActionResult Post(int id, string first_name, string last_name, string email, string telephone)
        {
            if (string.IsNullOrEmpty(first_name)) {
                return new JsonResult(new { errormessage = "First name was empty", success = false });
            }

            var user = GameUsers.Domain.User.CreateUser(id, first_name, last_name, email, telephone);

            var existingUser = _userRepository.GetById(id);

            if (existingUser == null)
            {
                _userRepository.Create(user);
            }
            else {
                _userRepository.Update(user);
            }

            return new JsonResult(new { success = true });
        }

        [HttpPut("{id}/{first_name}/{last_name}/{email}/{telephone}")]
        public ActionResult Put(int id, string first_name, string last_name, string email, string telephone)
        {
            if (string.IsNullOrEmpty(first_name))
            {
                return new JsonResult(new { errormessage = "First name was empty", success = false });
            }

            var user = GameUsers.Domain.User.CreateUser(id, first_name, last_name, email, telephone);

            _userRepository.Update(user);

            return new JsonResult(new { success = true });
        }
    }
}
