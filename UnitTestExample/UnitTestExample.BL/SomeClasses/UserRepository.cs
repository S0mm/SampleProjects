using UnitTestExample.BL.Models;

namespace UnitTestExample.BL.SomeClasses
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}