using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using ST10291238_PROG6212_POE.Controllers;
using ST10291238_PROG6212_POE.Models;
using ST10291238_PROG6212_POE.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ST10291238_PROG6212_POETest
{
    [TestClass]
    public class ClaimDisplayControllerTests
    {
        private ClaimDisplayController _controller;
        private ApplicationDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDbContext(options);
            _controller = new ClaimDisplayController(_context);
        }

        [TestMethod]
        public async Task ClaimDetails_ClaimExists_ReturnsViewWithClaim()
        {
            // Arrange
            var claim = new ClaimsTable
            {
                ClaimId = 1,
                LecturerName = "John",
                LecturerSurname = "Doe",
                Programme = "Software Engineering",
                ClaimDate = System.DateTime.Now,
                HourlyRate = 40,
                HoursWorked = 8,
                Status = "Approved"
            };
            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.ClaimDetails(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            var model = viewResult.Model as ClaimsTable;
            Assert.AreEqual(1, model.ClaimId);
            Assert.AreEqual("John", model.LecturerName);
        }

        [TestMethod]
        public async Task ClaimDetails_ClaimNotFound_ReturnsNotFound()
        {
            // Act
            var result = await _controller.ClaimDetails(99);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
