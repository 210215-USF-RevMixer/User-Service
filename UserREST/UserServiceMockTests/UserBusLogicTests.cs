using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UserBL;
using UserDL;
using UserModels;
using UserREST.Controllers;
using Xunit;


namespace UserTests
{
    public class UserBusLogicTests

    {
        private Mock<IUserRepoDB> _userBusLogicMock;

        public UserBusLogicTests()
        {
            _userBusLogicMock = new Mock<IUserRepoDB>();
            
        }

        [Fact]
        public async Task AddReportAsync_ShouldReturn_NewReport_WhenReportIsValid()
        {
            //arrange
            var newReport = new Report();
            _userBusLogicMock.Setup(i => i.AddReportAsync(It.IsAny<Report>())).Returns(Task.FromResult<Report>(newReport));
            var newUserBusLogic = new UserBusLogic(_userBusLogicMock.Object);

            //act
            var result = await newUserBusLogic.AddReportAsync(newReport);

            //assert
            Assert.Equal(newReport, result); 
        }
        /*public async Task<Report> AddReportAsync(Report newReport)
        {
            return await _repo.AddReportAsync(newReport);
        }*/


        [Fact]
        public async Task AddUserAsync_ShouldReturn_NewUser_WhenUserIsValid()
        {
            //arrange
            var newUser = new User();
            _userBusLogicMock.Setup(i => i.AddUserAsync(It.IsAny<User>())).Returns(Task.FromResult<User>(newUser));
            var newUserBusLogic = new UserBusLogic(_userBusLogicMock.Object);

            //act
            var result = await newUserBusLogic.AddUserAsync(newUser);

            //assert
            Assert.Equal(newUser, result);
        }
        /* public async Task<User> AddUserAsync(User newUser)
        {
            return await _repo.AddUserAsync(newUser);
        }*/



        [Fact]
        public async Task DeleteReportAsync_ShouldReturn_Report2BDeleted_WhenReportIsValid()
        {
            //arrange
            var newReport = new Report();
            _userBusLogicMock.Setup(i => i.DeleteReportAsync(It.IsAny<Report>())).Returns(Task.FromResult<Report>(newReport));
            var newUserBusLogic = new UserBusLogic(_userBusLogicMock.Object);

            //act
            var result = await newUserBusLogic.DeleteReportAsync(newReport);

            //assert
            Assert.Equal(newReport, result);
            _userBusLogicMock.Verify(i => i.DeleteReportAsync(It.IsAny<Report>()));
        }
        /*  public async Task<Report> DeleteReportAsync(Report report2BDeleted)
        {
            return await _repo.DeleteReportAsync(report2BDeleted);
        }
*/



        [Fact]
        public async Task GetAllReportsAsync_ShouldReturnReports()
        {
            //arrange
            List<Report> reports = new List<Report> { new Report() { Id = 1 } };
            _userBusLogicMock.Setup(i => i.GetAllReportsAsync()).Returns(Task.FromResult<List<Report>>(reports));
            var newUserBusLogic = new UserBusLogic(_userBusLogicMock.Object);

            //act
            var result = await newUserBusLogic.GetAllReportsAsync();

            //assert
            Assert.Single(result);
            _userBusLogicMock.Verify(i => i.GetAllReportsAsync());
        }


    [Fact]
        public async Task GetReportByID_ShouldReturnID_WhenIdIsValid()
        {
            //arrange
            int id = 1;
            var newReport = new Report();
            _userBusLogicMock.Setup(i => i.GetReportByIdAsync(It.IsAny<int>())).Returns(Task.FromResult<Report>(newReport));
            var newUserBusLogic = new UserBusLogic(_userBusLogicMock.Object);

            //act
            var result = await newUserBusLogic.GetReportByIdAsync(id);

            //assert
            Assert.Equal(newReport, result);
            _userBusLogicMock.Verify(i => i.GetReportByIdAsync(It.IsAny<int>()));
        }
        /*public async Task<Report> GetReportByIdAsync(int Id)
    {
        return await _repo.GetReportByIdAsync(Id);
    }*/

        [Fact]
        public async Task GetUserByEmailAsync_ShouldReturnUser_WhenEmailIsValid()
        {
            //arrange
            var newUser = new User() { Email = "user@email.com"};
            _userBusLogicMock.Setup(i => i.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(newUser);
            var newUserBusLogic = new UserBusLogic(_userBusLogicMock.Object);

            //act
            var result = await newUserBusLogic.GetUserByEmail(newUser.Email);

            //assert
            Assert.Equal(newUser.Email, result.Email);
            _userBusLogicMock.Verify(i => i.GetUserByEmail(It.IsAny<string>()));


        }


        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnID_WhenIdIsValid()
        {
            //arrange
            int id = 1;
            var newUser = new User();
            _userBusLogicMock.Setup(i => i.GetUserByIDAsync(It.IsAny<int>())).Returns(Task.FromResult<User>(newUser));
            var newUserBusLogic = new UserBusLogic(_userBusLogicMock.Object);

            //act
            var result = await newUserBusLogic.GetUserByIDAsync(id);

            //assert
            Assert.Equal(newUser, result);
            _userBusLogicMock.Verify(i => i.GetUserByIDAsync(It.IsAny<int>()));
        }
        ///* public async Task<User> GetUserByIDAsync(int Id)
        //{
        //    return await _repo.GetUserByIDAsync(Id);
        //}*/



        [Fact]
        public async Task UpdateReportAsync_ShouldReturn_Report2BUpdated()
        {
            //arrange
            var newReport = new Report();
            _userBusLogicMock.Setup(i => i.UpdateReportAsync(It.IsAny<Report>())).Returns(Task.FromResult<Report>(newReport));
            var newUserBusLogic = new UserBusLogic(_userBusLogicMock.Object);

            //act
            var result = await newUserBusLogic.UpdateReportAsync(newReport);

            //assert
            Assert.Equal(newReport, result);
            _userBusLogicMock.Verify(i => i.UpdateReportAsync(It.IsAny<Report>()));
        }

   /*  public async Task<Report> UpdateReportAsync(Report report2BUpdated)
        {
            return await _repo.UpdateReportAsync(report2BUpdated);
        }*/

        [Fact]
        public async Task UpdateUserAsync_ShouldReturn_User2BUpdated()
        {
            //arrange
            var newUser = new User();
            _userBusLogicMock.Setup(i => i.UpdateUserAsync(It.IsAny<User>())).Returns(Task.FromResult<User>(newUser));
            var newUserBusLogic = new UserBusLogic(_userBusLogicMock.Object);

            //act
            var result = await newUserBusLogic.UpdateUserAsync(newUser);

            //assert
            Assert.Equal(newUser, result);
            _userBusLogicMock.Verify(i => i.UpdateUserAsync(It.IsAny<User>()));
        }

        /*    public async Task<User> UpdateUserAsync(User user2BUpdated)
        {
            return await _repo.UpdateUserAsync(user2BUpdated);
        }*/

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
