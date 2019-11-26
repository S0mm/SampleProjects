using UnitTestExample.BL.Models;

namespace UnitTestExample.BL.SomeClasses
{
    public interface IUserRepository
    {
        User GetUser(string name);
        bool Add(User user);
    }
}