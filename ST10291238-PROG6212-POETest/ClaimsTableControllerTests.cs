using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using ST10291238_PROG6212_POE.Controllers;
using ST10291238_PROG6212_POE.Models;
using ST10291238_PROG6212_POE.Data;
using Microsoft.EntityFrameworkCore;

namespace ST10291238_PROG6212_POETest
{
    [TestClass]
    public class ClaimsTableControllerTests
    {
        private ClaimsTableController _controller;
        private Mock<ApplicationDbContext> _mockContext;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _mockContext = new Mock<ApplicationDbContext>(options);
            _controller = new ClaimsTableController(_mockContext.Object);
        }

        [TestMethod]
        public async Task Submit_ValidClaim_ReturnsRedirectToMyClaims()
        {
            // Arrange
            var claim = new ClaimsTable
            {
                LecturerName = "John",
                LecturerSurname = "Doe",
                Programme = "Computer Science",
                HourlyRate = 50,
                HoursWorked = 10,
                ClaimDate = System.DateTime.Now,
                Status = "Pending",
                Notes = "Additional Notes"
            };

            var fileMock = new Mock<IFormFile>();
            var content = "Fake File Content";
            var fileName = "testfile.pdf";
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write(content);
            writer.Flush();
            memoryStream.Position = 0;

            fileMock.Setup(f => f.OpenReadStream()).Returns(memoryStream);
            fileMock.Setup(f => f.FileName).Returns(fileName);
            fileMock.Setup(f => f.Length).Returns(memoryStream.Length);

            // Act
            var result = await _controller.Submit(claim, fileMock.Object);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("MyClaims", redirectToActionResult.ActionName);
        }
    }
}
