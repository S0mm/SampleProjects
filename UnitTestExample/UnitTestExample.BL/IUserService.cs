using UnitTestExample.BL.Models;

namespace UnitTestExample.BL
{
    public interface IUserService
    {
        User GetUser(string name);
        User CreateUser(string title, string name, int age);
        bool CreateUserOrNotify(string name, int age);
    }
}