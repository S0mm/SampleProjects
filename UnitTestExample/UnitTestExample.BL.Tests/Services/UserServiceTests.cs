using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestExample.BL.Models;
using UnitTestExample.BL.Services;
using UnitTestExample.BL.SomeClasses;

namespace UnitTestExample.BL.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void CreateUser_ValidParameters_Positive()
        {
            // arrange
            var userRepository = new UserRepository();
            var notificationService = new NotificationService();

            var userService = new UserService(userRepository, notificationService);

            // act
            var result = userService.CreateUser("Mr", "Smith", 31);

            // assert
            Assert.AreEqual("Mr", result.Title);
            Assert.AreEqual("Smith", result.Name);
            Assert.AreEqual(31, result.Age);
        }

        [TestMethod]
        public void CreateUser_EmptyTitle_Positive()
        {
            // arrange
            var userRepository = new UserRepository();
            var notificationService = new NotificationService();

            var userService = new UserService(userRepository, notificationService);

            // act
            var result = userService.CreateUser(null, "Smith", 31);

            // assert
            Assert.AreEqual("Sir/Madam", result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "too young")]
        public void CreateUser_InvalidAge_Negative()
        {
            // arrange
            var userRepository = new UserRepository();
            var notificationService = new NotificationService();

            var userService = new UserService(userRepository, notificationService);

            // act
            var result = userService.CreateUser("Mr", "Smith", 17);
        }

        [TestMethod]
        public void CreateUser_InvalidAgeV2_Negative()
        {
            // arrange
            var userRepository = new UserRepository();
            var notificationService = new NotificationService();

            var userService = new UserService(userRepository, notificationService);

            // act and assert
            var ex = Assert.ThrowsException<ValidationException>(() =>
                userService.CreateUser("Mr", "Smith", 17));

            Assert.AreEqual("too young", ex.Message);
        }

        [TestMethod]
        public void CreateUserOrNotify_ValidParameters_True()
        {
            // arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var notificationService = new Mock<INotificationService>();

            userRepositoryMock
                .Setup(e => e.Add(It.IsAny<User>()))
                .Returns(true);

            notificationService
                .Setup(e => e.TooYoungNotification(It.IsAny<string>()));
                

            var userService = new UserService(userRepositoryMock.Object, notificationService.Object);

            // act
            var result = userService.CreateUserOrNotify("Smith", 25);

            // assert
            Assert.IsTrue(result);

            userRepositoryMock.Verify(
                mock => mock.Add(It.IsAny<User>()),
                Times.Once());

            notificationService.Verify(
                mock => mock.TooYoungNotification(It.IsAny<string>()),
                Times.Never());
        }

        [TestMethod]
        public void CreateUserOrNotify_InvalidAge_False()
        {
            // arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var notificationService = new Mock<INotificationService>();

            string nameToVerify = null;

            userRepositoryMock
                .Setup(e => e.Add(It.IsAny<User>()))
                .Returns(true);

            notificationService
                .Setup(e => e.TooYoungNotification(It.IsAny<string>()))
                .Callback<string>(name => nameToVerify = name);

            var userService = new UserService(userRepositoryMock.Object, notificationService.Object);

            // act
            var result = userService.CreateUserOrNotify("Smith", 17);

            // assert
            Assert.IsFalse(result);

            userRepositoryMock.Verify(
                mock => mock.Add(It.IsAny<User>()),
                Times.Never());

            notificationService.Verify(
                mock => mock.TooYoungNotification(It.IsAny<string>()),
                Times.Once());

            Assert.AreEqual("Smith", nameToVerify);
        }
    }
}