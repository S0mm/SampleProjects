using System.ComponentModel.DataAnnotations;
using UnitTestExample.BL.Models;
using UnitTestExample.BL.SomeClasses;

namespace UnitTestExample.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;

        public UserService(IUserRepository userRepository, INotificationService notificationService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public User GetUser(string name)
        {
            var user = _userRepository.GetUser(name);

            return user;
        }

        public User CreateUser(string title, string name, int age)
        {
            if (age < 18)
            {
                throw new ValidationException("too young");
            }

            var user = new User
            {
                Name = name,
                Age = age,
                Title = title ?? "Sir/Madam"
            };

            return user;
        }

        public bool CreateUserOrNotify( string name, int age)
        {
            if (age < 18)
            {
                _notificationService.TooYoungNotification(name);

                return false;
            }

            var user = new User
            {
                Name = name,
                Age = age
            };

            bool isSuccessful = _userRepository.Add(user);

            return isSuccessful;
        }
    }
}
