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
    public class ReportControllerTest
    {
        private Mock<IUserBL> _userBLMock;

        public ReportControllerTest()
        {
            _userBLMock = new Mock<IUserBL>();
        }
        [Fact]
         public async Task GetReportsAsyncShouldReturnReports()
        {
            //arrange
            Report report = new Report();
            _userBLMock.Setup(i => i.GetAllReportsAsync());
            ReportController reportController = new ReportController(_userBLMock.Object);

            //act 
            var result = await reportController.GetReportsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetReportByIdShouldGetreport()
        {
            var reportId = 1;
            var report = new Report { Id = reportId };
            _userBLMock.Setup(x => x.GetReportByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(report));
            var reportController = new ReportController(_userBLMock.Object);
            var result = await reportController.GetReportByIdAsync(reportId);
            Assert.Equal(reportId, ((Report)((OkObjectResult)result).Value).Id);
            _userBLMock.Verify(x => x.GetReportByIdAsync(reportId));
        }
        [Fact]
        public async Task AddReportShouldAddReport()
        {
            var report = new Report();
            _userBLMock.Setup(x => x.AddReportAsync(It.IsAny<Report>())).Returns(Task.FromResult<Report>(report));
            var reportController = new ReportController(_userBLMock.Object);
            var result = await reportController.AddReportAsync(new Report());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _userBLMock.Verify(x => x.AddReportAsync((It.IsAny<Report>())));
        }
        [Fact]
        public async Task DeleteReportShouldDeleteReport()
        {
            var report = new Report { Id = 1 };
            _userBLMock.Setup(x => x.DeleteReportAsync(It.IsAny<Report>())).Returns(Task.FromResult<Report>(report));
            var reportController = new ReportController(_userBLMock.Object);
            var result = await reportController.DeleteReportAsync(report.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _userBLMock.Verify(x => x.DeleteReportAsync((It.IsAny<Report>())));
        }
        [Fact]
        public async Task UpdateReportShouldUpdateReport()
        {
            var report = new Report { Id = 1 };
            _userBLMock.Setup(x => x.UpdateReportAsync(It.IsAny<Report>())).Returns(Task.FromResult(report));
            var reportController = new ReportController(_userBLMock.Object);
            var result = await reportController.UpdateReportAsync(report.Id, report);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _userBLMock.Verify(x => x.UpdateReportAsync(report));

        }

    }
}