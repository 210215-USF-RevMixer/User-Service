using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using UserBL;
using UserModels;
using UserREST.Controllers;
using Xunit;


namespace UserTests
{
    public class UserMockTests
    {



        [Fact]
        public async Task AddUserAsync_ShouldReturnCreatedAtAction_WhenUserIsValid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            User user = new User();
            userBLMock.Setup(i => i.AddUserAsync(user)).ReturnsAsync(user);
            var userController = new UserController(userBLMock.Object);

            //act
            var result = await userController.AddUserAsync(user);

            //assert
            Assert.IsType<CreatedAtActionResult>(result);

        }

        [Fact]
        public async Task AddUserAsync_ShouldReturnStatusCode400_WhenUserIsInvalid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            User user = null;
            userBLMock.Setup(i => i.AddUserAsync(user)).Throws(new Exception());
            UserController userController = new UserController(userBLMock.Object);

            //act
            var result = await userController.AddUserAsync(user);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);
        }


        [Fact]
        public async Task GetUserByEmailAsync_ShouldReturnOKObjectResult_WhenEmailIsValid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            User user = new User();
            string userEmail = "user@email.com";
            userBLMock.Setup(i => i.GetUserByEmail(userEmail)).ReturnsAsync(user);
            UserController userController = new UserController(userBLMock.Object);

            //act
            var result = await userController.GetUserByEmail(userEmail);

            //assert
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task GetUserByEmailAsync_ShouldReturnNotFound_WhenEmailIsInvalid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            User user = null;
            string userEmail = "user@email.com";
            userBLMock.Setup(i => i.GetUserByEmail(userEmail)).ReturnsAsync(user);
            UserController userController = new UserController(userBLMock.Object);

            //act
            var result = await userController.GetUserByEmail(userEmail);

            //assert
            Assert.IsType<NotFoundResult>(result);

        }
        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnOkObjectResult_WhenIDIsValid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            User user = new User();
            int id = 1;
            userBLMock.Setup(i => i.GetUserByIDAsync(id)).ReturnsAsync(user);
            UserController userController = new UserController(userBLMock.Object);

            //act
            var result = await userController.GetUserByIDAsync(id);

            //assert
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnNotFound_WhenIdIsInvalid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            User user = null;
            int id = -51;
            userBLMock.Setup(i => i.GetUserByIDAsync(id)).ReturnsAsync(user);
            UserController userController = new UserController(userBLMock.Object);

            //act
            var result = await userController.GetUserByIDAsync(id);

            //assert
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async Task UpdateUserAsync_ShouldReturnNoContent_WhenUserAndIdIsValid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            int id = 1;
            User user = new User();
            userBLMock.Setup(i => i.UpdateUserAsync(user)).ReturnsAsync(user);
            UserController userController = new UserController(userBLMock.Object);
            //act
            var result = await userController.UpdateUserAsync(id, user);

            //assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldReturnStatusCode500_WhenUserIsInvalid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            int id = -41;
            User user = null;
            userBLMock.Setup(i => i.UpdateUserAsync(user)).Throws(new Exception());
            UserController userController = new UserController(userBLMock.Object);
            //act
            var result = await userController.UpdateUserAsync(id, user);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }

        //[Fact]
        //public async Task GetAllUsersAsync_ShouldReturnOkObjectResult()
        //{
        //    //arrange
        //    var userBLMock = new Mock<IUserBL>();
        //    User user = new User();
        //    userBLMock.Setup(i => i.GetAllUsersAsync());
        //    UserController userController = new UserController(userBLMock.Object);

        //    //act 
        //    var result = await userController.GetAllUsersAsync();

        //    //assert
        //    Assert.IsType<OkObjectResult>(result);
        //}

 

    }
}
