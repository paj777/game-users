using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameUsers.Core.Interfaces;
using GameUsers.Domain;

namespace GameUsers.Data.Repositories
{
    public class MockUserRepository : IRepository<User>
    {
        private readonly List<User> _users = MockData.GetUsers().ToList();

        public void Create(User entity)
        {
            _users.Add(entity);
        }

        public void Delete(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            if (user != null) {
                _users.Remove(user);
            }
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return _users;
        }

        public void Update(User entity)
        {
            var user = _users.FirstOrDefault(x => x.Id == entity.Id);

            user?.UpdateUser(entity);
        }
    }
}
