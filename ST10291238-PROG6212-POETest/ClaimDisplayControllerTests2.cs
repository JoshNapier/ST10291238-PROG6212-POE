using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10291238_PROG6212_POE.Controllers;
using ST10291238_PROG6212_POE.Models;
using ST10291238_PROG6212_POE.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST10291238_PROG6212_POETest
{
    [TestClass]
    public class ClaimDisplayControllerTests2
    {
        private ApplicationDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDbContext(options);
        }

        [TestMethod]
        public async Task SelectClaims_ReturnsListOfClaims()
        {
            // Arrange
            var claims = new List<ClaimsTable>
            {
                new ClaimsTable
                {
                    ClaimId = 1,
                    LecturerName = "Alice",
                    LecturerSurname = "Johnson",
                    Programme = "IT",
                    HoursWorked = 5,
                    HourlyRate = 40,
                    ClaimDate = System.DateTime.Now
                },
                new ClaimsTable
                {
                    ClaimId = 2,
                    LecturerName = "Bob",
                    LecturerSurname = "Smith",
                    Programme = "Business",
                    HoursWorked = 7,
                    HourlyRate = 30,
                    ClaimDate = System.DateTime.Now
                }
            };

            _context.Claims.AddRange(claims);
            await _context.SaveChangesAsync();

            // Act
            var result = await ClaimDisplayController.SelectClaims(_context);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Alice", result[0].LecturerName);
            Assert.AreEqual("Bob", result[1].LecturerName);
        }
    }
}
