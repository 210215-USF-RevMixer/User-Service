using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBL;
using UserModels;
using UserREST.Controllers;
using Xunit;

namespace UserTests
{
    public class ReportMockTests
    {
        [Fact]
        public async Task AddReportAsync_ShouldReturnCreatedAtActionResult_WhenValid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            var report = new Report() { Description = "Test Report" };
            userBLMock.Setup(i => i.AddReportAsync(report)).ReturnsAsync(report);
            var reportController = new ReportController(userBLMock.Object);

            //act
            var result = await reportController.AddReportAsync(report);
            //assert
            Assert.IsType<CreatedAtActionResult>(result);
            var returnedReport = ((CreatedAtActionResult)result).Value;
            Assert.Equal(report.Description, ((Report)returnedReport).Description);

        }

        [Fact]
        public async Task AddReportAsync_ShouldReturnStatusCode400_WhenInvalid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            Report report = null;
            userBLMock.Setup(i => i.AddReportAsync(report)).Throws(new Exception());
            var reportController = new ReportController(userBLMock.Object);

            //act
            var result = await reportController.AddReportAsync(report);


            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);

        }


        [Fact]
        public async Task DeleteReportAsync_ShouldReturnNoContent_WhenIDIsValid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            int id = 1;
            User user = new User();
            Report report = new Report();
            userBLMock.Setup(i => i.GetReportByIdAsync(id));
            userBLMock.Setup(i => i.DeleteReportAsync(report)).ReturnsAsync(report);
            ReportController reportController = new ReportController(userBLMock.Object);

            //act
            var result = await reportController.DeleteReportAsync(id);

            //assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteReportAsync_ShouldReturnStatusCode500_WhenIDIsInvalid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            int id = -71;
            User user = new User();
            Report report = null;
            userBLMock.Setup(i => i.GetReportByIdAsync(id));
            userBLMock.Setup(i => i.DeleteReportAsync(report)).Throws(new Exception());
            ReportController reportController = new ReportController(userBLMock.Object);

            //act
            var result = await reportController.DeleteReportAsync(id);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }
        [Fact]
        public async Task GetAllReportsAsync_ShouldReturnOKObjectResult()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            Report report = new Report();
            userBLMock.Setup(i => i.GetAllReportsAsync());
            ReportController reportController = new ReportController(userBLMock.Object);

            //act 
            var result = await reportController.GetReportsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task GetReportByIdAsync_ShouldReturn_OKObjectResult_WhenIDisValid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            int id = 1;
            Report report = new Report();

            userBLMock.Setup(i => i.GetReportByIdAsync(id)).ReturnsAsync(report);
            ReportController reportController = new ReportController(userBLMock.Object);

            //act
            var result = await reportController.GetReportByIdAsync(id);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetReportByIdAsync_ShouldReturn_NotFound_WhenIdIsInvalid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            int id = -5;
            Report report = null;

            userBLMock.Setup(i => i.GetReportByIdAsync(id)).ReturnsAsync(report);
            ReportController reportController = new ReportController(userBLMock.Object);

            //act
            var result = await reportController.GetReportByIdAsync(id);

            //assert
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async Task UpdateReportAsync_ShouldReturnNoContent_WhenReportAndIdIsValid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            int id = 1;
            Report report = new Report();
            userBLMock.Setup(i => i.UpdateReportAsync(report)).ReturnsAsync(report);
            ReportController reportController = new ReportController(userBLMock.Object);

            //act
            var result = await reportController.UpdateReportAsync(id, report);

            //assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateReportAsync_ShouldReturnStatusCode500_WhenReportIsInvalid()
        {
            //arrange
            var userBLMock = new Mock<IUserBL>();
            int id = -11;
            Report report = null;
            userBLMock.Setup(i => i.UpdateReportAsync(report)).Throws(new Exception());
            ReportController reportController = new ReportController(userBLMock.Object);

            //act
            var result = await reportController.UpdateReportAsync(id, report);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);

        }


    }
}
