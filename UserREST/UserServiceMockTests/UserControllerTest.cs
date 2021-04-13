using UserBL;
using UserModels;
using UserREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UserServiceMocktests
{
    public class UserControllerTest
    {
        private Mock<IUserBL> _userBLMock;

        public UserControllerTest()
        {
            _userBLMock = new Mock<IUserBL>();
        }
         public async Task GetUsersAsyncShouldReturnUsers()
        {
            //arrange
            User sample = new User();
            _userBLMock.Setup(i => i.GetUsersAsync());
            UserController userController = new UserController(_userBLMock.Object);

            //act 
            var result = await userController.GetUsersAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetUserByIdShouldGetUser()
        {
            var userId = 1;
            var user = new User { Id = userId };
            _userBLMock.Setup(x => x.GetUserByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(user));
            var userController = new UserController(_userBLMock.Object);
            var result = await userController.GetUserByIDAsync(userId);
            Assert.Equal(userId, ((User)((OkObjectResult)result).Value).Id);
            _userBLMock.Verify(x => x.GetUserByIDAsync(userId));
        }
        [Fact]
        public async Task AddUserShouldAddUser()
        {
            var user = new User();
            _userBLMock.Setup(x => x.AddUserAsync(It.IsAny<User>())).Returns(Task.FromResult<User>(user));
            var userController = new UserController(_userBLMock.Object);
            var result = await userController.AddUserAsync(new User());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _userBLMock.Verify(x => x.AddUserAsync((It.IsAny<User>())));
        }
        [Fact]
        public async Task DeleteUserShouldDeleteUser()
        {
            var user = new User { Id = 1 };
            _userBLMock.Setup(x => x.DeleteUserAsync(It.IsAny<User>())).Returns(Task.FromResult<User>(user));
            var userController = new UserController(_userBLMock.Object);
            var result = await userController.DeleteUserAsync(user.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _userBLMock.Verify(x => x.DeleteUserAsync((It.IsAny<User>())));
        }
        [Fact]
        public async Task GetUserByEmailShouldGetUser()
        {
            var userEmail = "test@email.com";
            var user = new User { Email = userEmail };
            _userBLMock.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(Task.FromResult(user));
            var userController = new UserController(_userBLMock.Object);
            var result = await userController.GetUserByEmail(userEmail);
            Assert.Equal(userEmail, ((User)((OkObjectResult)result).Value).Email);
            _userBLMock.Verify(x => x.GetUserByEmail(userEmail));
        }
        [Fact]
        public async Task UpdateUserShouldUpdateUser()
        {
            var user = new User { Id = 1 };
            _userBLMock.Setup(x => x.UpdateUserAsync(It.IsAny<User>())).Returns(Task.FromResult(user));
            var userController = new UserController(_userBLMock.Object);
            var result = await userController.UpdateUserAsync(user.Id, user);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _userBLMock.Verify(x => x.UpdateUserAsync(user));

        }

    }
}