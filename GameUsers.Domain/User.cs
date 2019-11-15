using System.Runtime.InteropServices.ComTypes;

namespace GameUsers.Domain
{
    public class User
    {
        private User(int id, string firstName, string lastName, string email, string telephone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
        }

        public static User CreateUser(int id, string firstName, string lastName, string email, string telephone)
        {
            return new User(id, firstName, lastName, email, telephone);
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Telephone { get; private set; }
    }
}
